using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.Service
{
    public class UserService : IUserService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = @"SELECT us.[Id]
                              ,us.[IsActive]
                              ,us.[CreatedOn]
                              ,us.[CreatedBy]
                              ,us.[UpdatedOn]
                              ,us.[UpdatedBy]
                              ,us.[Name]
                              ,us.[UserType]
                              ,us.[UserName]
                              ,us.[Email]
                              ,us.[Mobile]
                              ,us.[Password]
                              ,u.[Name] as UserType
                          FROM [dbo].[Users]us
                       if
                        UserType = 3
                          inner join UserConfig u on u.Id= us.[UserType]
                            order by u.UpdatedOn desc";
        string ValidateUserQuery = @"SELECT [Id]
                              ,[Name]
                              ,[UserType]
                              ,[UserName]
                              ,[Email]
                              ,[Mobile]
                          FROM [dbo].[Users] ";
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
        string selectByIdQuery = @"SELECT [Id]
                              ,[IsActive]
                              ,[Name]
                              ,[UserType]
                              ,[UserName]
                              ,[Email]
                              ,[Mobile]                              
                          FROM [dbo].[Users] ";
        string deleteQuery = "Delete from Users";

    

        public void Add(IModel model)
        {
            var user = (User)model;
            user.IsActive = true;
            dbHelper.Add(insertQuery, user);
        }
        public User ValidateUser(string userName, string pwd)
        {
            var users = dbHelper.FetchData<User>($"{ValidateUserQuery} where UserName='{userName}' and Password = '{pwd}'");
            return users.FirstOrDefault();
        }

        public void Delete(int id)
        {
            dbHelper.Delete($"{deleteQuery} where id ={id}", new User { Id = id });
        }

        public IList<User> GetAll<User>()
        {
            var UserList = dbHelper.FetchData<User>($"{selectQuery}");
            return UserList;
        }
       
        public IList<User> GetById<User>(int id)
        {
            var UserList = dbHelper.FetchData<User>($"{selectByIdQuery} where  id =  {id}");
            return UserList;
        }

        public void Update(IModel model)
        {
            var user = (User)model;
            
            dbHelper.Update(updateQuery, user);

        }

      
    }
}
