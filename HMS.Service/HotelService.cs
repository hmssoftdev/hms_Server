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
        string deleteQuery = "Delete from Hotel";
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
            dbHelper.Delete($"{deleteQuery} where id ={id}", new HotelTable { Id = id });
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
            dbHelper.Update($"UPDATE [dbo].[HotelTable] SET [IsBooked] = {(hotel.IsBooked? 1 : 0)} WHERE ID = {hotel.Id}", hotel);
        }
    }
}
