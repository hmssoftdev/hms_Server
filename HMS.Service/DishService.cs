using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class DishService : IDishService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                                  ,[IsActiv]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                                  ,[Description]
                                  ,[HalfPrice]
                                  ,[FullPrice]
                                  ,[HotelId]
                                  ,[MainCategoryId]
                                  ,[IsVeg]
                                  ,[IsHalf]
                                  ,[IsFull]
                                   FROM[dbo].[Dish]";       
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

        public IList<Dish> GetAll<Dish>()
        {
            var dishList = dbHelper.FetchData<Dish>($"{selectQuery}");
            return dishList;
        }

        public IList<Dish> GetById<Dish>(int id)
        {
            var dishList = dbHelper.FetchData<Dish>($"{selectQuery} where id ={id}");
            return dishList;
        }

        public void Updat(IModel model)
        {
            throw new NotImplementedException();
        }

    }
}
