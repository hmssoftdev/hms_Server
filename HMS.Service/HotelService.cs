using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class HotelService : IHotelService
    {
        IDbHelper dbHelper;

        public HotelService(IDbHelper dbHelper)
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
                          FROM [dbo].[Hotel]";
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
                          FROM[dbo].[Hotel]
                            where [CreatedBy] = @CreatedBy
                           ";
        string insertQuery = @"INSERT INTO [dbo].[Hotel]
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
        string updateQuery = @"UPDATE [dbo].[Hotel]
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
        string deleteQuery = "Delete from Hotel";
        string selectUpdateQuery = @"UPDATE [dbo].[Hotel]
                       SET [IsActive] =@IsActive
                          ,[CreatedOn] =@CreatedOn
                          ,[CreatedBy] =@CreatedBy
                          ,[UpdatedOn] =@UpdatedOn
                          ,[UpdatedBy] =@UpdatedBy
                          ,[IsBooked] =@IsBooked
                     WHERE Id=@Id";
        public void Add(IModel model)
        {
            var hotel = (Hotel)model;
            hotel.IsActive = true;
            dbHelper.Add(insertQuery, hotel);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new Hotel { Id = id });
        }

        public IList<Hotel> GetAll<Hotel>()
        {
            var HotelList = dbHelper.FetchData<Hotel>($"{selectQuery}");
            return HotelList;
        }

        public IList<Hotel> GetById<Hotel>(int id)
        {
            var HotelList = dbHelper.FetchData<Hotel>($"{selectQuery} where id ={id}");
            return HotelList;
        }

        public void Update(IModel model)
        {
            var hotel = (Hotel)model;
            dbHelper.Update(updateQuery, hotel);
        }
        //public void UpdateBooked(IModel model)
        //{
        //    var hotel = (Hotel)model;
        //    dbHelper.Update(selectUpdateQuery, hotel);
        //}
        public IList<Hotel> GetAllByHotelId<Hotel>(int id)
        {
            var obj = new { CreatedBy = id };
            var HotelList = dbHelper.FetchDataByParam<Hotel>(selectByHotelQuery, obj);
            return HotelList;
        }

        public void UpdateBookedSeat(IModel model)
        {
            var hotel = (Hotel)model;
            dbHelper.Update(selectUpdateQuery, hotel);
        }
        public void UpdateSeatId(IModel model)
        {
            var hotel = (Hotel)model;
            dbHelper.Update($"UPDATE [dbo].[Hotel] SET [IsBooked] = {hotel.IsBooked} WHERE ID = {hotel.Id}", hotel);
        }

        //public void Update(Hotel hotel)
        //{
        //    //var hotel = (Hotel)model;
        //    dbHelper.Update($"UPDATE [dbo].[Hotel] SET [IsBooked] = {hotel.IsBooked} WHERE ID = {hotel.Id}", hotel);

        //}
    }
}
