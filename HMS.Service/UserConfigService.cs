using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class UserConfigService : IUserConfigService
    {
        IDbHelper dbHelper;

        public UserConfigService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        string selectQuery = @"SELECT  u.[UserName]
                              ,u.[Email]
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,u.[Id]
                              ,u.[IsActive]
                              ,u.[CreatedOn]
                              ,u.[CreatedBy]
                              ,u.[UpdatedOn]
                              ,u.[UpdatedBy]
                              ,u.[Contact]
	                          ,st.[Name] as State
	                          ,ct.[Name] as City
	                          FROM [dbo].[UserConfig] u
                          left join StateMaster st on st.Id = u.[StateId]
                          left join CityMaster ct on ct.Id = u.[CityId]
                          order by u.UpdatedOn desc";
        string insertQuery = @"INSERT INTO [dbo].[UserConfig]
                                   ([UserName]
                                   ,[Email]
                                   ,[Address]
                                   ,[CityId]
                                   ,[StateId]
                                   ,[PinCode]
                                   ,[IsActive]
                                   ,[CreatedOn]
                                   ,[CreatedBy]
                                   ,[UpdatedOn]
                                   ,[UpdatedBy]
                                   ,[Contact])
                             VALUES
                                   (@UserName
                                   ,@Email
                                   ,@Address
                                   ,@CityId
                                   ,@StateId
                                   ,@PinCode
                                   ,@IsActive
                                   ,@CreatedOn
                                   ,@CreatedBy
                                   ,@UpdatedOn
                                   ,@UpdatedBy
                                   ,@Contact)";
        string updateQuery = @"UPDATE [dbo].[UserConfig]
                               SET [UserName] =@UserName
                                  ,[Email] =@Email
                                  ,[Address] =@Address
                                  ,[CityId] =@CityId
                                  ,[StateId] =@StateId
                                  ,[PinCode] =@PinCode
                                  ,[IsActive] =@IsActive
                                  ,[CreatedOn] =@CreatedOn
                                  ,[CreatedBy] =@CreatedBy
                                  ,[UpdatedOn] =@UpdatedOn
                                  ,[UpdatedBy] =@UpdatedBy
                                  ,[Contact] =@Contact
                             WHERE Id=@Id";
        string selectByIdQuery = @"SELECT  u.[UserName]
                              ,u.[Email]
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,u.[Id]
                              ,u.[IsActive]
                              ,u.[CreatedOn]
                              ,u.[CreatedBy]
                              ,u.[UpdatedOn]
                              ,u.[UpdatedBy]
                              ,u.[Contact]
	                          ,st.[Name] as State
	                          ,ct.[Name] as City
	                          FROM [dbo].[UserConfig] u
                          inner join StateMaster st on st.Id = u.[StateId] 
						  inner join CityMaster ct on ct.Id=u.[CityId]
						  where u.Id=";
        string deleteQuery = "Delete from UserConfig";

        public IList<object> UserConfigList { get; private set; }

        public void Add(IModel model)
        {
            var userConfig = (UserConfig)model;
            userConfig.IsActive = true;
            dbHelper.Add(insertQuery, userConfig);
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new UserConfig { Id = id });
        }

        public IList<UserConfig> GetAll<UserConfig>()
        {
            var UserConfigList = dbHelper.FetchData<UserConfig>($"{selectQuery}");
            return UserConfigList;
        }
       
        public IList<UserConfig> GetById<UserConfig>(int id)
        {
            var UserConfigList = dbHelper.FetchData<UserConfig>($"{selectByIdQuery} {id}");
            return UserConfigList;
        }

        public void Update(IModel model)
        {
            var userConfig = (UserConfig)model;
            
            dbHelper.Update(updateQuery, userConfig);

        }
    }
}
