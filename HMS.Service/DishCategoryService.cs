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
        string insertQuery = "";
        string updateQuery = "";
        string deleteQuery = "";
        public void Add(IModel model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
