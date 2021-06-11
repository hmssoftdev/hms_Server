﻿using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class DishService : IDishService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                                  ,[IsActive]
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
        string insertQuery = @"INSERT INTO [dbo].[Dish]
                                   ([IsActive]
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
                                   ,[IsFull])
                             VALUES
                                   (@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@Name
                                   ,@Description
                                   ,@HalfPrice
                                   ,@FullPrice
                                   ,@HotelId
                                   ,@MainCategoryId
                                   ,@IsVeg
                                   ,@IsHalf
                                   ,@IsFull)";
        string updateQuery = "";
        string deleteQuery = "";

        public void Add(IModel model)
        {
            var dish = (Dish)model;
            dish.IsActive = true;
            dbHelper.Add(insertQuery, dish);
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
