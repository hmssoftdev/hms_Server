using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class DishService : IDishService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT  d.[Id]
                                      ,d.[IsActive]
                                      ,d.[CreatedOn]
                                      ,d.[CreatedBy]
                                      ,d.[UpdatedOn]
                                      ,d.[UpdatedBy]
                                      ,d.[Name]
                                      ,d.[Description]
                                      ,d.[HalfPrice]
                                      ,d.[FullPrice]
                                      ,d.[HotelId]
                                      ,d.[MainCategoryId]
                                      ,d.[Quantity]
                                      ,d.[TimeForCook]
                                      ,d.[IsVeg]
                                      ,d.[NonVegCategory]
                                      ,d.[status]
                                      ,d.[ImageUrl]
	                                  ,dc.[Name] as DishCategory
                                  FROM [dbo].[Dish] d
                                  inner join DishCategory dc on dc.Id = d.[MainCategoryId]
                                  order by d.UpdatedOn desc";       
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
                                                   ,[Quantity]
                                                   ,[TimeForCook]
                                                   ,[IsVeg]
                                                   ,[NonVegCategory]
                                                   ,[status]
                                                   ,[ImageUrl])
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
                                                   ,@Quantity
                                                   ,@TimeForCook
                                                   ,@IsVeg
                                                   ,@NonVegCategory
                                                   ,@status
                                                   ,@ImageUrl)";
        string updateQuery = @"UPDATE [dbo].[Dish] 
                                       SET [IsActive]=@IsActive
                                          ,[CreatedOn]=@CreatedOn
                                          ,[CreatedBy]=@CreatedBy
                                          ,[UpdatedOn]=@UpdatedOn
                                          ,[UpdatedBy]=@UpdatedBy
                                          ,[Name]=@Name
                                          ,[Description]=@Description
                                          ,[HalfPrice]=@HalfPrice
                                          ,[FullPrice]=@FullPrice
                                          ,[HotelId]=@HotelId
                                          ,[MainCategoryId]=@MainCategoryId
                                          ,[Quantity]=@Quantity
                                          ,[TimeForCook]=@TimeForCook
                                          ,[IsVeg]=@IsVeg
                                          ,[NonVegCategory]=@NonVegCategory
                                          ,[status]=@status
                                          ,[ImageUrl]=@ImageUrl
                                     WHERE Id=@Id";
        string selectByIdQuery = @"SELECT  d.[Id]
                                      ,d.[IsActive]
                                      ,d.[CreatedOn]
                                      ,d.[CreatedBy]
                                      ,d.[UpdatedOn]
                                      ,d.[UpdatedBy]
                                      ,d.[Name]
                                      ,d.[Description]
                                      ,d.[HalfPrice]
                                      ,d.[FullPrice]
                                      ,d.[HotelId]
                                      ,d.[MainCategoryId]
                                      ,d.[Quantity]
                                      ,d.[TimeForCook]
                                      ,d.[IsVeg]
                                      ,d.[NonVegCategory]
                                      ,d.[status]
                                      ,d.[ImageUrl]
	                                  ,dc.[Name] as DishCategory
                                  FROM [dbo].[Dish] d
                                  inner join DishCategory dc on dc.Id = d.[MainCategoryId] where d.id =";
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
            var dishList = dbHelper.FetchData<Dish>($"{selectByIdQuery} {id}");
            return dishList;
        }

        public void Update(IModel model)
        {
            var dish = (Dish)model;
            dbHelper.Update(updateQuery, dish);
        }

    }
}
