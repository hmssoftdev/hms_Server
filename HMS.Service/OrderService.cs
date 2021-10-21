using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service
{
    public class OrderService : IOrderService
    {
        IDbHelperOrder _dbHelper;
        string orderAddQuery = @"INSERT INTO [dbo].[DishOrder]
                               ([DeliveryTotal]
                               ,[GrossTotal]
                               ,[ItemCount]
                               ,[ItemTotal]
                               ,[AdminId]  
                               ,[DeliveryOptionId]
                               ,[PaymentMode]
                               ,[UserId]
                               ,[CreatedOn]
                               ,[CreatedBy]
                               ,[UpdatedOn]
                               ,[UpdatedBy]
                               ,[IsActive]
                              ,[DiscountInPercent]
                              ,[DiscountInRupees]
                              ,[AdditionalAmount])
                         VALUES
                               (@DeliveryTotal
                               ,@GrossTotal
                               ,@ItemCount
                               ,@ItemTotal
                               ,@AdminId
                               ,@DeliveryOptionId
                               ,@PaymentMode
                               ,@UserId
                               ,@CreatedOn
                               ,@CreatedBy
                               ,@UpdatedOn
                               ,@UpdatedBy
                               ,@IsActive
                               ,@DiscountInPercent
                               ,@DiscountInRupees
                               ,@AdditionalAmount)";
        string orderItemAddQuery = @"INSERT INTO [dbo].[OrderItem]
                                   ([Quantity]
                                   ,[ProductId]
                                   ,[Price]
                                   ,[GstCompliance]
                                   ,[GstPrice]
                                   ,[IsFull]
                                   ,[OrderID]
                                   ,[IsActive]
                                   ,[CreatedOn]
                                   ,[CreatedBy]
                                   ,[UpdatedOn]
                                   ,[UpdatedBy]
                                   ,[GstTotal]
                                   ,[KotPrinted])
                             VALUES
                                   (@Quantity
                                   ,@ProductId
                                   ,@Price
                                   ,@GstCompliance
                                   ,@GstPrice
                                   ,@IsFull
                                   ,@OrderID
                                   ,@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@GstTotal
                                   ,@KotPrinted)";
        string orderStatusAddQuery = @"INSERT INTO [dbo].[OrderStatus]
                                       ([OrderId]
                                       ,[Status]
                                       ,[IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy])
                                 VALUES
                                       (@OrderId
                                       ,@Status
                                       ,@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy)";
        string orderTableAddQuery =@"INSERT INTO [dbo].[OrderTable]
                           ([OrderId]
                           ,[TableId]
                           ,[CreatedBy]
                           ,[UpdatedBy]
                           ,[CreatedOn]
                           ,[UpdatedOn])
                     VALUES
                           (@OrderId
                           ,@TableId
                           ,@CreatedBy
                           ,@UpdatedBy
                           ,@CreatedOn
                           ,@UpdatedOn)
                ";
        string selectByHotelQuery = @"SELECT o.[Id]
                                      ,o.[DeliveryTotal]
                                      ,o.[GrossTotal]
                                      ,o.[ItemCount]
                                      ,o.[ItemTotal]
                                      ,o.[AdminId]
                                      ,o.[DeliveryOptionId]
                                      ,o.[PaymentMode]
                                      ,o.[UserId]
                                      ,o.[CreatedOn]
                                      ,o.[CreatedBy]
                                      ,o.[UpdatedOn]
                                      ,o.[UpdatedBy]
                                      ,o.[IsActive]
                                      ,o.[DiscountInPercent]
                                      ,o.[DiscountInRupees]
                                      ,o.[AdditionalAmount]
									  ,u.[UserName] as UserName
									  ,u.[Contact] as UserMobileNumber
									  ,(SELECT Top 1 
									  [Status]
  FROM [hms_db].[dbo].[OrderStatus]where OrderId=o.Id order by Id desc) status
                                  FROM [dbo].[DishOrder] o
								  inner join Users u on u.Id=o.userId
                                    where o.[CreatedBy] =@CreatedBy and 
									cast(o.[CreatedOn] as Date) = cast(getdate() as Date)
								order by UpdatedOn desc";
        string selectStatusByOrderIdQuery = @"select Id,
                                        OrderId,
                                        Status,
                                        IsActive,
                                        CreatedOn,
                                        CreatedBy,
                                        UpdatedOn,
                                        UpdatedBy from OrderStatus where OrderId = @id order by UpdatedOn asc";
        string selectOrderItemByOrderIdQuery = @"select o.*, d.Name DishName from 
                                                orderItem o
                                                inner join dish d on o.ProductId = d.Id
                                                where orderid = @id";
        string orderUpdateQuery = @"UPDATE [dbo].[DishOrder]
                               SET [DeliveryTotal] =@DeliveryTotal
                                  ,[GrossTotal] = @GrossTotal
                                  ,[ItemCount] = @ItemCount
                                  ,[ItemTotal] =@ItemTotal
                                  ,[AdminId] = @AdminId
                                  ,[DeliveryOptionId] =@DeliveryOptionId
                                  ,[PaymentMode] =@PaymentMode
                                  ,[UserId] =@UserId
                                  ,[CreatedOn] =@CreatedOn
                                  ,[CreatedBy] =@CreatedBy
                                  ,[UpdatedOn] =@UpdatedOn
                                  ,[UpdatedBy] =@UpdatedBy
                                  ,[IsActive] =@IsActive
                                  ,[DiscountInPercent] =@DiscountInPercent
                                  ,[DiscountInRupees] =@DiscountInRupees
                                  ,[AdditionalAmount] =@AdditionalAmount
                             WHERE Id=@Id";
        string orderItemUpdateQuery = @"UPDATE [dbo].[OrderItem]
                                   SET[Quantity] =@Quantity
                                      ,[ProductId] =@ProductId
                                      ,[Price] = @Price
                                      ,[GstCompliance] =@GstCompliance
                                      ,[GstPrice] =@GstPrice
                                      ,[IsFull] = @IsFull
                                      ,[OrderID] = @OrderID
                                      ,[IsActive] = @IsActive
                                      ,[CreatedOn] =@CreatedOn
                                      ,[CreatedBy] =@CreatedBy
                                      ,[UpdatedOn] =@UpdatedOn
                                      ,[UpdatedBy] =@UpdatedBy
                                      ,[GstTotal] =@GstTotal
                                      ,[KotPrinted] =@KotPrinted
                                WHERE Id=@Id";
        string orderStatusUpdateQuery =@"UPDATE [dbo].[OrderStatus]
                           SET[OrderId] =@OrderId
                              ,[Status] =@Status
                              ,[IsActive] =@IsActive
                              ,[CreatedOn] =@CreatedOn
                              ,[CreatedBy] = @CreatedBy
                              ,[UpdatedOn] =@UpdatedOn
                              ,[UpdatedBy] =@UpdatedBy
                        WHERE Id=@Id";
        public OrderService(IDbHelperOrder dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void Add(IModel model)
        {
            var order = (DishOrder)model;
            order.IsActive = true;
           
            _dbHelper.OrderTransaction(order,orderAddQuery,orderItemAddQuery,orderStatusAddQuery, orderTableAddQuery);
        }
        public void AddStatus(OrderStatus status)
        {
            status.IsActive = true;
            _dbHelper.Add(orderStatusAddQuery, status);
        }
       
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IList<DishOrder> GetAllByHotelId<DishOrder>(int id)
        {
            var obj = new { CreatedBy = id };
            var orderList = _dbHelper.FetchDataByParam<DishOrder>(selectByHotelQuery, obj);
            return orderList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderStatus> GetStatusByOrderId(int OrderId)
        {
            var obj = new { id = OrderId};
            var orderstatus = _dbHelper.FetchDataByParam<OrderStatus>(selectStatusByOrderIdQuery, obj);
            return (List<OrderStatus>)orderstatus;
        }

        public List<Domain.Model.OrderItem> GetOrderItemByOrderId(int OrderId)
        {
            var obj = new { id = OrderId };
            var orderItem = _dbHelper.FetchDataByParam<Domain.Model.OrderItem>(selectOrderItemByOrderIdQuery, obj);
            return orderItem.ToList();
        } 

        public void Update(IModel model)
        {
            var order = (DishOrder)model;
            _dbHelper.OrderTransaction(order, orderUpdateQuery, orderItemUpdateQuery, orderStatusUpdateQuery,"");
        }
        public void Add(OrderItem item)
        {
            item.IsActive = true;
            _dbHelper.Add(orderItemAddQuery, item);
        }

        public void Update(OrderItem item)
        {
            
            _dbHelper.Update(orderItemUpdateQuery, item);
        }
    }
}
