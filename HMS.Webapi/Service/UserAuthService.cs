using HMS.Domain;
using HMS.Service;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;
namespace HMS.Webapi { 
public interface IUserAuthService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    AuthenticateResponse AuthenticateAdmin(int id);
    IEnumerable<User> GetAll();
    User GetById(int id);
}

public class UserAuthService : IUserAuthService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>();
        

    private readonly AppSettings _appSettings;
        private IUserService _userService;

        public UserAuthService(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
            
        var user = _userService.ValidateUser(model.Username, model.Password);

            // return null if user not found
            if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }
        public AuthenticateResponse AuthenticateAdmin(int id)
        {

            var user = _userService.ValidateUser(id);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
            var userList =   _userService.GetById<User>(id);
            return userList.FirstOrDefault();
            //return _users.FirstOrDefault(x => x.Id == id);
        }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),


        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
} }