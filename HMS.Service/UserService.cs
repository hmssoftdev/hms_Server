using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HMS.Service 
{
    public class UserService : IUserService
    {
        IDbHelper dbHelper;
        ICryptoHelperService _cryptoHelperService;
        public UserService(IDbHelper dbHelper, ICryptoHelperService cryptoHelperService)
        {
            this.dbHelper = dbHelper;
            _cryptoHelperService = cryptoHelperService;
        }
        string selectQuery = @"SELECT u.[Id]
                              ,u.[IsActive]
                              ,u.[CreatedOn]
                              ,u.[CreatedBy]
                              ,u.[UpdatedOn]
                              ,u.[UpdatedBy]
                              ,u.[Name]
                              ,u.[UserType]
                              ,u.[UserName]
                              ,u.[Email]
                              ,u.[Contact]
                              ,u.[Password]
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,st.[Name] as State
	                          ,ct.[Name] as City
                          FROM [dbo].[Users] u
                          left join StateMaster st on st.Id = u.[StateId]
                          left join CityMaster ct on ct.Id = u.[CityId]";
        string selectByHotelQuery = @"SELECT u.[Id]
                              ,u.[IsActive]
                              ,u.[CreatedOn]
                              ,u.[CreatedBy]
                              ,u.[UpdatedOn]
                              ,u.[UpdatedBy]
                              ,u.[Name]
                              ,u.[UserType]
                              ,u.[UserName]
                              ,u.[Email]
                              ,u.[Contact]
                              ,u.[Password]
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,st.[Name] as State
	                          ,ct.[Name] as City
                          FROM [dbo].[Users] u
                          left join StateMaster st on st.Id = u.[StateId]
                          left join CityMaster ct on ct.Id = u.[CityId]
                          where u.[CreatedBy] = @CreatedBy";
        string selectAllAdmin = @"SELECT u.[Id]
                              ,u.[IsActive]
                              ,u.[CreatedOn]
                              ,u.[CreatedBy]
                              ,u.[UpdatedOn]
                              ,u.[UpdatedBy]
                              ,u.[Name]
                              ,u.[UserType]
                              ,u.[UserName]
                              ,u.[Email]
                              ,u.[Contact]
                              ,u.[Password]
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,st.[Name] as State
	                          ,ct.[Name] as City
                          FROM [dbo].[Users] u
                          left join StateMaster st on st.Id = u.[StateId]
                          left join CityMaster ct on ct.Id = u.[CityId] where UserType=2";
        string ValidateUserQuery = @"SELECT [Id]
                              ,[Name]
                              ,[UserType]
                              ,[UserName]
                              ,[Email]
                              ,[Contact]
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
                               ,[Contact]
                               ,[Password]
                               ,[Address]
                              ,[CityId]
                              ,[StateId]
                              ,[PinCode])
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
                               ,@Contact
                               ,@Password
                               ,@Address
                              ,@CityId
                              ,@StateId
                              ,@PinCode)";
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
                                  ,[Contact] =    @Contact
                                  ,[Password] =  @Password 
                                  ,[Address]=@Address
                                  ,[CityId]=@CityId
                                  ,[StateId]=@StateId
                                  ,[PinCode]=@PinCode
                             WHERE id = @id";
        string updatePasswordQuery = @"UPDATE [dbo].[Users]
                                    SET [Password] =  @Password                                  
                                    WHERE id = @id";
        string forgatePasswordQuery = @"UPDATE [dbo].[Users]
                                    SET [resetPasswordLink] =  @resetPasswordLink                                  
                                    WHERE[Email] = @Email";
        string selectByIdQuery = @"SELECT u.[Id]
                              ,u.[IsActive]
                              ,u.[Name]
                              ,u.[UserType]
                              ,u.[UserName]
                              ,u.[Email]
                              ,u.[Contact] 
                              ,u.[Address]
                              ,u.[CityId]
                              ,u.[StateId]
                              ,u.[PinCode]
                              ,st.[Name] as State
	                          ,ct.[Name] as City
                          FROM [dbo].[Users] u
                          left join StateMaster st on st.Id = u.[StateId]
                          left join CityMaster ct on ct.Id = u.[CityId]
                           where u.Id=";
        string deleteQuery = "Delete from Users";
        string forgatePasswordResetQuery = @"UPDATE [dbo].[Users]
                                    SET [Password] =  @Password                                  
                                    WHERE[Email] = @Email";
        string CheckUserEmailAndMobileQuery = @"select * from users where Email= @Email OR Contact=@Contact ";
        string VerifyEmailQuery = @"update users set IsEmailVerified = 1 where email = @Email";

        string CheckUserEmailQuery = @"select count(1) from users where email = @value";
        string CheckUsercontactQuery = @"select count(1) from users where Contact = @value";
        string CheckUserUserNameQuery = @"select count(1) from users where UserName = @value";
        
        public void Add(IModel model)
        {
            var user = (User)model;
            user.IsActive = true;
            dbHelper.Add(insertQuery, user);
        }
        public User ValidateUser(string userName, string pwd)
        {
            var users = dbHelper.FetchData<User>($"{ValidateUserQuery}  where (UserName='{userName}'or Email='{userName}'or Contact='{userName}') and Password = '{pwd}'");
            return users.FirstOrDefault();
        }

        public User ValidateUser(int id)
        {
            var users = dbHelper.FetchData<User>($"{ValidateUserQuery}  where (id='{id}')");
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
            var UserList = dbHelper.FetchData<User>($"{selectByIdQuery} {id}");
            return UserList;
        }

        public void Update(IModel model)
        {
            var user = (User)model;

            dbHelper.Update(updateQuery, user);

        }

        public IList<User> GetAllByHotelId<User>(int id)
        {
            var obj = new { CreatedBy = id };
            var UserList = dbHelper.FetchDataByParam<User>(selectByHotelQuery, obj);
            return UserList;

        }

        public IList<User> GetAllAdmin<User>()
        {
            var UserList = dbHelper.FetchData<User>(selectAllAdmin);
            return UserList;

        }

        public bool UpdatePassword(string oldPwd, string newPwd, int userId)
        {
            var obj = new { Id = userId, password = oldPwd };
            var users = dbHelper.FetchDataByParam<User>($"{ValidateUserQuery}  where  Id=@Id and Password = @password ", obj);
            var user = users.FirstOrDefault();
            if (user == null)
                return false;

            var updateObject = new User { Id = userId, Password = newPwd };
            dbHelper.Update(updatePasswordQuery, updateObject);
            return true;
        }

        public string ForgotPassword(string email, string url)
        {
            var link = $"{email}/{DateTime.UtcNow.AddHours(24)}";
            link = $"{url}/resetPassword?param={_cryptoHelperService.encrypt(link)}";
            var updateObject = new User { Email = email, ResetPasswordLink = link };
            dbHelper.Update(forgatePasswordQuery, updateObject);
            return link;
        }

        public string ResetPassword(string email, string pwd)
        {
            throw new NotImplementedException();
        }
        public bool ForgetPasswordReset(string encryptedLink, string passwrod)
        {
            string detail = _cryptoHelperService.Decrypt(encryptedLink);
            var detailArr = detail.Split(new[] { '/' }, 2);
            var email = detailArr[0];
            var date = DateTime.Parse(detailArr[1]);
            var result = date.CompareTo(DateTime.UtcNow);
            if (result < 0)
                return false;

            var pwd = _cryptoHelperService.Decrypt(passwrod);
            var updateObject = new User { Email = email, Password = pwd };
            dbHelper.Update(forgatePasswordResetQuery, updateObject);
            return true;
        }
        //public User ValidateUser(int id)
        //{
        //   //var obj = new { CreatedBy = id };
        //    var users = dbHelper.FetchData<User>($"{ValidateUserQuery}  where (id='{id}'");
        //    return users.FirstOrDefault();
        //}

        public bool CheckUserEmailAndMobile(IModel model)
        {
            var user = (User)model;
            var obj = new { Email = user.Email, Contact = user.Contact };
            var userList = dbHelper.FetchDataByParam<User>(CheckUserEmailAndMobileQuery, obj);
            return !userList.Any() ? true : false;
        }

        public int VerifyEmail(string email)
        {
            var updateObject = new User { Email = email };
            dbHelper.Update(VerifyEmailQuery, updateObject);
            return 1;
        }

        public bool CheckUserData(string key, string value)
        {
            var obj = new {  value = value};
            switch (key)
            {
                case "email":
                    return dbHelper.GetCount(CheckUserEmailQuery, obj) > 1 ? true : false;                   
                case "contact":
                    return dbHelper.GetCount(CheckUsercontactQuery, obj) > 1 ? true : false;
                case "userName":
                    return dbHelper.GetCount(CheckUserUserNameQuery, obj) > 1 ? true : false;
                default:
                    return true;
            }
        }

    }
}
