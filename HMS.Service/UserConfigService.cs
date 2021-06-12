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
        string insertQuery =@"INSERT INTO [dbo].[UserConfig]
                           ([UserName]
                           ,[Email]
                           ,[Address]
                           ,[City]
                           ,[State]
                           ,[PinCode]
                           ,[IsActive]
                           ,[CreatedOn]
                           ,[CreatedBy]
                           ,[UpdatedOn]
                           ,[UpdatedBy])
                     VALUES
                           (@UserName
                           , @Email
                           , @Address
                           , @City
                           , @State
                           , @PinCode
                           , @IsActive
                           , @CreatedOn
                           , @CreatedBy
                           , @UpdatedOn
                           , @UpdatedBy)";
        string updateQuery = @"UPDATE [dbo].[UserConfig]
                           SET [UserName] =@UserName
                              ,[Email] =@Email
                              ,[Address] =@Address
                              ,[City] =@City
                              ,[State] =@State
                              ,[PinCode] =@PinCode
                              ,[IsActive] =@IsActive
                              ,[CreatedOn] =@CreatedOn
                              ,[CreatedBy] =@CreatedBy
                              ,[UpdatedOn] =@UpdatedOn
                              ,[UpdatedBy] =@UpdatedBy
                         WHERE Id=@Id";
        string deleteQuery = "";

        public IList<object> UserConfigList { get; private set; }

        public void Add(IModel model)
        {
            var userConfig = (UserConfig)model;
            userConfig.IsActive = true;
            dbHelper.Add(insertQuery, userConfig);
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

        public void Update(IModel model)
        {
            var userConfig = (UserConfig)model;
            
            dbHelper.Update(updateQuery, userConfig);

        }
    }
}
