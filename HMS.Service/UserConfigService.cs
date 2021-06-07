using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class UserConfigService : IUserConfigService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [UserName]
                                  ,[Email]
                                  ,[Address]
                                  ,[City]
                                  ,[State]
                                  ,[PinCode]
                                  ,[Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                              FROM [dbo].[UserConfig]";
        string insertQuery = "";
        string updateQuery = "";
        string deleteQuery = "";

        public IList<object> UserConfigList { get; private set; }

        public void Add(IModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UserConfig> GetAll<UserConfig>()
        {
            var UserConfigList = dbHelper.FetchData<UserConfig>($"{selectQuery}");
            return UserConfigList;
        }
       
        public IList<UserConfig> GetById<UserConfig>(int id)
        {
            var UserConfigList = dbHelper.FetchData<UserConfig>($"{selectQuery} where id ={id}");
            return UserConfigList;
        }

        public void Updat(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
