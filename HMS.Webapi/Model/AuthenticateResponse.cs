

using HMS.Domain;

namespace  HMS.Webapi
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int userType { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.UserName;
            userType = user.UserType;
            Token = token;
        }
    }
} 