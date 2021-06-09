using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class AdminService : IAdminService
    {
        DbHelper dbHelper = new DbHelper();

        string selectQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[BusinessName]
                              ,[Category]
                              ,[FoodLincNum]
                              ,[Address]
                              ,[Gst]
                              ,[AccountName]
                              ,[AccountNumber]
                              ,[BankName]
                              ,[IfscCode]
                              ,[PinCode]
                              ,[RestaurentLogo]
                              ,[Signature]
                              ,[TermAndCondition]
                          FROM[dbo].[Admin]";
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

        public IList<Admin> GetAll<Admin>()
        {
            var AdminList = dbHelper.FetchData<Admin>($"{selectQuery}");
            return AdminList;
        }

        public IList<Admin> GetById<Admin>(int id)
        {
            var AdminList = dbHelper.FetchData<Admin>($"{selectQuery} where id ={id}");
            return AdminList;
        }

        public void Updat(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
