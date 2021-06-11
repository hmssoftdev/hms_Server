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
                                   ,[BankAddress]
                              FROM [dbo].[Admin]";
        string insertQuery = @"INSERT INTO [dbo].[Admin]
                                   ([IsActive]
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
                                   ,[BankAddress])
                             VALUES
                                   (@IsActive 
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@BusinessName
                                   ,@Category
                                   ,@FoodLincNum
                                   ,@Address
                                   ,@Gst
                                   ,@AccountName
                                   ,@AccountNumber
                                   ,@BankName
                                   ,@IfscCode
                                   ,@PinCode
                                   ,@RestaurentLogo
                                   ,@Signature
                                   ,@TermAndCondition
                                   ,@BankAddress)";
        string updateQuery = "";
        string deleteQuery = "";
        public void Add(IModel model)
        {
            var admin = (Admin)model;
            admin.IsActive = true;
            dbHelper.Add(insertQuery, admin);
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
