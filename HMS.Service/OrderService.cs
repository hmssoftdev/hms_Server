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
                              ,[AdditionalAmount]
                              ,[GstTotal]
                              ,[InvoiceNumber])
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
                               ,@AdditionalAmount
                               ,@GstTotal
                               ,@InvoiceNumber)";
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
        string orderTableAddQuery = @"INSERT INTO [dbo].[OrderTable]
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
                                      ,o.[GstTotal] 
                                      ,o.[InvoiceNumber]  
									  ,u.[UserName] as UserName
									  ,u.[Contact] as UserMobileNumber
									  ,(SELECT Top 1 
									  [Status]
  FROM [hms_db].[dbo].[OrderStatus]where OrderId=o.Id order by Id desc) status
                                  FROM [dbo].[DishOrder] o
								  inner join Users u on u.Id=o.userId
                                    where o.[CreatedBy] =@CreatedBy and o.IsActive = 1 and
									cast(o.[CreatedOn] as Date) = @CreatedOn
								order by UpdatedOn desc";

        string selectByHotelQueryAndDateRange = @"SELECT o.[Id]
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
                                      ,o.[InvoiceNumber]
                                      ,o.[GstTotal]  
									  ,u.[UserName] as UserName
									  ,u.[Contact] as UserMobileNumber
									  ,(SELECT Top 1 
									  [Status]
  FROM [hms_db].[dbo].[OrderStatus]where OrderId=o.Id order by Id desc) status
                                  FROM [dbo].[DishOrder] o
								  inner join Users u on u.Id=o.userId
                                    where o.[CreatedBy] =@CreatedBy and o.IsActive = 1 and 
									cast(o.[CreatedOn] as Date) between @Min and @Max
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
        string selectOrderItem = "";
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
                                  ,[GstTotal] = @GstTotal  
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
        string orderStatusUpdateQuery = @"UPDATE [dbo].[OrderStatus]
                           SET[OrderId] =@OrderId
                              ,[Status] =@Status
                              ,[IsActive] =@IsActive
                              ,[CreatedOn] =@CreatedOn
                              ,[CreatedBy] = @CreatedBy
                              ,[UpdatedOn] =@UpdatedOn
                              ,[UpdatedBy] =@UpdatedBy
                        WHERE Id=@Id";
        string releaseHotelTableQuery = @"update HotelTable set IsBooked = 0 
                                        from HotelTable ht inner join 
                                        OrderTable Ot on ht.Id = Ot.TableId
                                        where Ot.OrderId = @OrderId";
        string paymentModeUpdateQuery = @"UPDATE [dbo].[DishOrder]
                                   SET [PaymentMode] =@PaymentMode
                                      ,[UserId] =@UserId
                                 WHERE UserId=@userid";
        string orderDeleteQuery = "Update DishOrder set IsActive= 0 where id = @id";

        string OrderSummryQuery = @"SELECT sum(o.GrossTotal) TotalAmount,count( o.[DeliveryOptionId]) TotalBill ,DeliveryOptionId  FROM [dbo].[DishOrder] o
                                    where o.[CreatedBy] =@userId and o.IsActive = 1 and 
                                    cast(o.[CreatedOn] as Date) between @Min and @Max
                                    group by o.[DeliveryOptionId]";
        string GetInvouceByOrderId = "SELECT o.[InvoiceNumber] from [dbo].[DishOrder] o where o.Id =@id ";

        string GetOrderCountById = @"select count(*) from DishOrder where CreatedBy = @CreatedBy  and cast(CreatedOn as Date) = @Date";
        public OrderService(IDbHelperOrder dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void Add(IModel model)
        {
            var order = (DishOrder)model;
            order.IsActive = true;

            var obj = new { CreatedBy = order.CreatedBy, Date = DateTime.Now.ToString("yyyy-MM-dd") };
            var number = _dbHelper.GetCount(GetOrderCountById, obj) + 1;
            order.InvoiceNumber = $"{DateTime.Now.ToString("ddMMyyyy")}{order.CreatedBy}{number}";
            var dbId = _dbHelper.OrderTransaction(order, orderAddQuery, orderItemAddQuery, orderStatusAddQuery, orderTableAddQuery);
        }

        public int AddDataAndReturnId(IModel model)
        {
            var order = (DishOrder)model;

            var obj = new { CreatedBy = order.CreatedBy, Date = DateTime.Now.ToString("yyyy-MM-dd") };
            var number = _dbHelper.GetCount(GetOrderCountById, obj) + 1;
            order.InvoiceNumber = $"{DateTime.Now.ToString("ddMMyyyy")}{order.CreatedBy}{number}";

            order.IsActive = true;
            return _dbHelper.OrderTransaction(order, orderAddQuery, orderItemAddQuery, orderStatusAddQuery, orderTableAddQuery);
        }
        public void AddStatus(OrderStatus status)
        {
            status.IsActive = true;
            _dbHelper.Add(orderStatusAddQuery, status);
        }

        public void Delete(int id)
        {
            var obj = new { id = id };
            _dbHelper.Delete(orderDeleteQuery, obj);
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IList<DishOrder> GetAllByHotelId<DishOrder>(int id)
        {
            var obj = new { CreatedBy = id, CreatedOn = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyy-MM-dd") };
            var orderList = _dbHelper.FetchDataByParam<DishOrder>(selectByHotelQuery, obj);
            return orderList;
        }

        public IList<OrderItem> GetById<OrderItem>(int id)
        {
            var orderList = _dbHelper.FetchData<OrderItem>($"{selectOrderItemByOrderIdQuery} {id}");
            return orderList;
        }

        public List<OrderStatus> GetStatusByOrderId(int OrderId)
        {
            var obj = new { id = OrderId };
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
            _dbHelper.OrderTransaction(order, orderUpdateQuery, orderItemUpdateQuery, orderStatusUpdateQuery, "");
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

        public void ReleaseTable(int id)
        {
            var obj = new { OrderId = id };
            _dbHelper.Update(releaseHotelTableQuery, obj);
        }
        public void UpdatePayementModeId(int id)
        {
            var obj = new { OrderId = id };
            _dbHelper.Update(paymentModeUpdateQuery, obj);
            //_dbHelper.Update($"UPDATE[dbo].[DishOrder] SET[PaymentMode] = { order.PaymentMode} WHERE ID = {order.UserId}", obj);
        }

        public void UpdatePayementModeId(IModel model)
        {
            var order = (DishOrder)model;
            // _dbHelper.Update(paymentModeUpdateQuery, order);
            _dbHelper.Update($"UPDATE[dbo].[DishOrder] SET[PaymentMode] = { order.PaymentMode} WHERE ID = {order.Id}", order);
        }

        public DishOrder GetOrderByTableId(int tableId)
        {
            return _dbHelper.GetOrderDetailFromTableId(tableId);
        }

        public IList<DishOrder> GetAllByHotelQueryAndDateRange<DishOrder>(int id, string maxDate, string minDate)
        {
            var obj = new { CreatedBy = id, Max = maxDate, Min = minDate }; // DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyy-MM-dd") };
            var orderList = _dbHelper.FetchDataByParam<DishOrder>(selectByHotelQueryAndDateRange, obj);
            return orderList;
        }

        public IList<OrderSummary> GetOrderSummaryByDateRange(int id, string maxDate, string minDate)
        {
            var obj = new { userId = id, Max = maxDate, Min = minDate };
            var orderList = _dbHelper.FetchDataByParam<OrderSummary>(OrderSummryQuery, obj);
            if (orderList.Any())
            {
                orderList.Add(new OrderSummary
                {
                    DeliveryOptionId = 0,
                    TotalAmount = orderList.Sum(i => i.TotalAmount),
                    TotalBill = orderList.Sum(i => i.TotalBill)
                });
            }
            return orderList;
        }

        public string GetInvoiceNumberByOrderId(int id)
        {
            var obj = new { id = id };
            return _dbHelper.GetString(GetInvouceByOrderId, obj);
            //
        }
    }
}

