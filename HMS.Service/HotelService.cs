using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class HotelService : IHotelService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[Size]
                              ,[IsAc]
                              ,[Shape]
                              ,[BarcodeTest]
                          FROM [dbo].[Portal]";
        string insertQuery = @"NSERT INTO [dbo].[Portal]
                                       ([IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy]
                                       ,[Name]
                                       ,[Size]
                                       ,[IsAc]
                                       ,[Shape]
                                       ,[BarcodeTest])
                                 VALUES
                                       (@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy
                                       ,@Name
                                       ,@Size
                                       ,@IsAc
                                       ,@Shape
                                       ,@BarcodeTest)";
        string updateQuery = @"UPDATE [dbo].[Portal]
                       SET [IsActive] =@IsActive
                          ,[CreatedOn] =@CreatedOn
                          ,[CreatedBy] =@CreatedBy
                          ,[UpdatedOn] =@UpdatedOn
                          ,[UpdatedBy] =@UpdatedBy
                          ,[Name] =@Name
                          ,[Size] =@Size
                          ,[IsAc] =@IsAc
                          ,[Shape] =@Shape
                          ,[BarcodeTest] =@arcodeTest
                     WHERE Id=@Id";
        string deleteQuery = "";
        public void Add(IModel model)
        {
            var portal = (Hotel)model;
            portal.IsActive = true;
            dbHelper.Add(insertQuery, portal);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Hotel> GetAll<Portal>()
        {
            var PortalList = dbHelper.FetchData<Portal>($"{selectQuery}");
            return PortalList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel model)
        {
            var portal = (Hotel)model;

            dbHelper.Update(updateQuery, portal);
        }
    }
}
