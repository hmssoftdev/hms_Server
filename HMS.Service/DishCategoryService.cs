using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class DishCategoryService : IDishCategoryService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                                  ,[HotelId]
                              FROM[dbo].[DishCategory]";
        string insertQuery = @"INSERT INTO [dbo].[DishCategory]
                                   ([IsActive]
                                   ,[CreatedOn]
                                   ,[CreatedBy]
                                   ,[UpdatedOn]
                                   ,[UpdatedBy]
                                   ,[Name]
                                   ,[HotelId])
                             VALUES
                                   (@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@Name
                                   ,@HotelId)";
        string updateQuery = @"UPDATE [dbo].[DishCategory]
                                   SET [IsActive] =@IsActive
                                      ,[CreatedOn] =@CreatedOn
                                      ,[CreatedBy] =@CreatedBy
                                      ,[UpdatedOn] =@UpdatedOn
                                      ,[UpdatedBy] =@UpdatedBy
                                      ,[Name] =@Name
                                      ,[HotelId] =@HotelId
                                 WHERE Id=@Id";
        string deleteQuery = "";
        public void Add(IModel model)
        {
            var dishCategory = (DishCategory)model;
            dishCategory.IsActive = true;
            dbHelper.Add(insertQuery, dishCategory);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DishCategory> GetAll<DishCategory>()
        {
            var dishCategoryList = dbHelper.FetchData<DishCategory>($"{selectQuery}");
            return dishCategoryList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel model)
        {
            var dishCategory = (DishCategory)model;
           
            dbHelper.Update(updateQuery, dishCategory);
        }
    }
}
