using HMS.Domain;
using System;
using System.Collections.Generic;

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
                               ,[IsActive])
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
                               ,@IsActive)";
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
                                   ,[UpdatedBy])
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
                                   ,@UpdatedBy)";
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
									  ,us.[Name] as UserName
									  ,us.[Contact] as UserMobileNumber
									  ,(SELECT Top 1 
									  [Status]
  FROM [hms_db].[dbo].[OrderStatus]where OrderId=o.Id order by Id desc) status
                                  FROM [dbo].[DishOrder] o
								  inner join Users us on Us.Id=o.id
                                    where o.[CreatedBy] =@CreatedBy
								order by UpdatedOn desc";
        public OrderService(IDbHelperOrder dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void Add(IModel model)
        {
            var order = (DishOrder)model;
            order.IsActive = true;
           
            _dbHelper.OrderTransaction(order,orderAddQuery,orderItemAddQuery,orderStatusAddQuery);
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

            //  return  _dbHelper.GetOrderDetail(id);
        }

        public void Update(IModel model)
        {
            throw new NotImplementedException();
        }
       
    }
}
