using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class BusinessCategoryService : IBusinessCategoryService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                              FROM [dbo].[BusinessCategory]";
        string insertQuery = @"INSERT INTO [dbo].[BusinessCategory]
                                       ([IsActive]
                                       ,[CreatedOn]
                                       ,[CreatedBy]
                                       ,[UpdatedOn]
                                       ,[UpdatedBy]
                                       ,[Name])
                                 VALUES
                                       (@IsActive
                                       ,@CreatedOn
                                       ,@CreatedBy
                                       ,@UpdatedOn
                                       ,@UpdatedBy
                                       ,@Name)";
        string updateQuery = @"UPDATE [dbo].[BusinessCategory]
                               SET [IsActive] =@IsActive
                                  ,[CreatedOn] =@CreatedOn
                                  ,[CreatedBy] =@CreatedBy
                                  ,[UpdatedOn] =@UpdatedOn
                                  ,[UpdatedBy] =@UpdatedBy
                                  ,[Name] =@Name
                             WHERE Id=@Id";
        string deleteQuery = "Delete from BusinessCategory";
        public void Add(IModel model)
        {
            var businessCategory = (BusinessCategory)model;
            businessCategory.IsActive = true;
            dbHelper.Add(insertQuery, businessCategory);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new BusinessCategory { Id = id });
        }

        public IList<BusinessCategory> GetAll<BusinessCategory>()
        {
            var BusinessCategoryList = dbHelper.FetchData<BusinessCategory>($"{selectQuery}");
            return BusinessCategoryList;
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel model)
        {
            var businessCategory = (BusinessCategory)model;
          
            dbHelper.Update(updateQuery, businessCategory);
        }
    }
}
