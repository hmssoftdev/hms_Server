using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class HotelTableService : IHotelTableService
    {
        IDbHelper dbHelper;

        public HotelTableService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        string selectQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[Seat]
                              ,[IsAc]
                              ,[Shape]
                              ,[BarcodeTest]
                              ,[IsBooked] 
                          FROM [dbo].[HotelTable]";
        string selectByHotelQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[Seat]
                              ,[IsAc]
                              ,[Shape]
                              ,[BarcodeTest]
                              ,[IsBooked]
                          FROM[dbo].[HotelTable]
                            where [CreatedBy] = @CreatedBy
                           ";
        string insertQuery = @"INSERT INTO [dbo].[HotelTable]
                                       ([IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy]
                                       ,[Name]
                                       ,[Seat]
                                       ,[IsAc]
                                       ,[Shape]
                                       ,[BarcodeTest]
                                       ,[IsBooked])
                                 VALUES
                                       (@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy
                                       ,@Name
                                       ,@Seat
                                       ,@IsAc
                                       ,@Shape
                                       ,@BarcodeTest
                                       ,@IsBooked)";
        string updateQuery = @"UPDATE [dbo].[HotelTable]
                       SET [IsActive] =@IsActive
                          ,[CreatedOn] =@CreatedOn
                          ,[CreatedBy] =@CreatedBy
                          ,[UpdatedOn] =@UpdatedOn
                          ,[UpdatedBy] =@UpdatedBy
                          ,[Name] =@Name
                          ,[Seat] =@Seat
                          ,[IsAc] =@IsAc
                          ,[Shape] =@Shape
                          ,[BarcodeTest] =@BarcodeTest
                          ,[IsBooked] =@IsBooked
                     WHERE Id=@Id";
        string selectByIdQuery = "";
        string deleteQuery = "Delete from HotelTable";
        string selectUpdateQuery = @"UPDATE [dbo].[HotelTable]
                       SET [IsActive] =@IsActive
                          ,[CreatedOn] =@CreatedOn
                          ,[CreatedBy] =@CreatedBy
                          ,[UpdatedOn] =@UpdatedOn
                          ,[UpdatedBy] =@UpdatedBy
                          ,[IsBooked] =@IsBooked
                     WHERE Id=@Id";
        public void Add(IModel model)
        {
            var hotel = (HotelTable)model;
            hotel.IsActive = true;
            dbHelper.Add(insertQuery, hotel);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where Id =@Id", new { Id = id });
        }

        public IList<HotelTable> GetAll<HotelTable>()
        {
            var HotelList = dbHelper.FetchData<HotelTable>($"{selectQuery}");
            return HotelList;
        }

        public IList<Hotel> GetById<Hotel>(int id)
        {
            var HotelList = dbHelper.FetchData<Hotel>($"{selectQuery} where id ={id}");
            return HotelList;
        }

        public void Update(IModel model)
        {
            var hotel = (HotelTable)model;
            dbHelper.Update(updateQuery, hotel);
        }
        //public void UpdateBooked(IModel model)
        //{
        //    var hotel = (Hotel)model;
        //    dbHelper.Update(selectUpdateQuery, hotel);
        //}
        public IList<HotelTable> GetAllByHotelId<HotelTable>(int id)
        {
            var obj = new { CreatedBy = id };
            var HotelList = dbHelper.FetchDataByParam<HotelTable>(selectByHotelQuery, obj);
            return HotelList;
        }

        public void UpdateBookedSeat(IModel model)
        {
            var hotel = (HotelTable)model;
            dbHelper.Update(selectUpdateQuery, hotel);
        }
        public void UpdateSeatId(IModel model)
        {
            var hotel = (HotelTable)model;
            dbHelper.Update($"UPDATE [dbo].[HotelTable] SET [IsBooked] = {(hotel.IsBooked ? 1 : 0)} WHERE ID = {hotel.Id}", hotel);
            if (hotel.IsBooked)
                return;

            var obj = new { TableId = hotel.Id };
            var getOrderIdQuery = "Select TOP 1 OrderId from OrderTable where TableId =@TableId order by createdon desc";
            var orderTables = dbHelper.FetchDataByParam<OrderTable>(getOrderIdQuery, obj);
            if (orderTables.Count == 0)
                return;
            
            var orderStatusQuery = $"select top 1 * from [OrderStatus] where orderId ={orderTables[0].OrderId} order by id desc; ";
            var status = dbHelper.FetchData<OrderStatus>(orderStatusQuery);
            if (status.Count == 0)
                return;
            if (status[0].Status == 10 || status[0].Status == 4)
                return;

            var orderStatusAddQuery = $@"INSERT INTO [dbo].[OrderStatus]
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


            OrderStatus orderStatus = new OrderStatus { OrderId = orderTables[0].OrderId, Status = 10 }; // 10 == Cancelled
            dbHelper.Add(orderStatusAddQuery, orderStatus);                                                                                             
        }

        //public void Update(Hotel hotel)
        //{
        //    //var hotel = (Hotel)model;
        //    dbHelper.Update($"UPDATE [dbo].[Hotel] SET [IsBooked] = {hotel.IsBooked} WHERE ID = {hotel.Id}", hotel);

        //}
    }
}
