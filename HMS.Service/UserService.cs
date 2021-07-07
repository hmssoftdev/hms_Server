using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class UserService : IUserService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[UserType]
                              ,[UserName]
                              ,[Email]
                              ,[Mobile]
                              ,[Password]
                          FROM [dbo].[Users]";
        string insertQuery = @"INSERT INTO [dbo].[Users]
                               ([IsActive]
                               ,[CreatedOn]
                               ,[CreatedBy]
                               ,[UpdatedOn]
                               ,[UpdatedBy]
                               ,[Name]
                               ,[UserType]
                               ,[UserName]
                               ,[Email]
                               ,[Mobile]
                               ,[Password])
                         VALUES
                               (@IsActive
                               ,@CreatedOn
                               ,@CreatedBy
                               ,@UpdatedOn
                               ,@UpdatedBy
                               ,@Name
                               ,@UserType
                               ,@UserName
                               ,@Email
                               ,@Mobile
                               ,@Password)";
        string updateQuery = @"UPDATE [dbo].[Users]
                               SET [IsActive] =  @IsActive 
                                  ,[CreatedOn] = @CreatedOn
                                  ,[CreatedBy] = @CreatedBy
                                  ,[UpdatedOn] = @UpdatedOn
                                  ,[UpdatedBy] = @UpdatedBy
                                  ,[Name] =		 @Name		
                                  ,[UserType] =  @UserType 
                                  ,[UserName] =  @UserName 
                                  ,[Email] =     @Email
                                  ,[Mobile] =    @Mobile
                                  ,[Password] =  @Password 
                             WHERE id = @id";
        string selectByIdQuery = @"";
        string deleteQuery = "";

        public IList<object> UserConfigList { get; private set; }

        public void Add(IModel model)
        {
            var userConfig = (User)model;
            userConfig.IsActive = true;
            dbHelper.Add(insertQuery, userConfig);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll<User>()
        {
            var UserConfigList = dbHelper.FetchData<User>($"{selectQuery}");
            return UserConfigList;
        }
       
        public IList<User> GetById<User>(int id)
        {
            var UserConfigList = dbHelper.FetchData<User>($"{selectByIdQuery} {id}");
            return UserConfigList;
        }

        public void Update(IModel model)
        {
            var userConfig = (User)model;
            
            dbHelper.Update(updateQuery, userConfig);

        }
    }
}
