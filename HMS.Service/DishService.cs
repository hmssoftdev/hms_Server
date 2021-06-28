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
                                  FROM [hms].[dbo].[Dish] d
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
                                                   (@d.IsActive
                                                   ,@d.CreatedOn
                                                   ,@d.CreatedBy
                                                   ,@d.UpdatedOn
                                                   ,@d.UpdatedBy
                                                   ,@d.Name
                                                   ,@d.Description
                                                   ,@d.HalfPrice
                                                   ,@d.FullPrice
                                                   ,@d.HotelId
                                                   ,@d.MainCategoryId
                                                   ,@d.Quantity
                                                   ,@d.TimeForCook
                                                   ,@d.IsVeg
                                                   ,@d.NonVegCategory
                                                   ,@d.status
                                                   ,@d.ImageUrl)";
        string updateQuery = @"UPDATE [dbo].[Dish] 
                                       SET [IsActive]=@d.IsActive
                                          ,[CreatedOn]=@d.CreatedOn
                                          ,[CreatedBy]=@d.CreatedBy
                                          ,[UpdatedOn]=@d.UpdatedOn
                                          ,[UpdatedBy]=@d.UpdatedBy
                                          ,[Name]=@d.Name
                                          ,[Description]=@d.Description
                                          ,[HalfPrice]=@d.HalfPrice
                                          ,[FullPrice]=@d.FullPrice
                                          ,[HotelId]=@d.HotelId
                                          ,[MainCategoryId]=@d.MainCategoryId
                                          ,[Quantity]=@d.Quantity
                                          ,[TimeForCook]=@d.TimeForCook
                                          ,[IsVeg]=@d.IsVeg
                                          ,[NonVegCategory]=@d.NonVegCategory
                                          ,[status]=@d.status
                                          ,[ImageUrl]=@d.ImageUrl
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
                                  FROM [hms].[dbo].[Dish] d
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
