using AutoMapper;
using FluentEmail.Core;
using FluentEmail.Smtp;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HMS.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserAuthService _userAuthService;
        ICryptoHelperService _cryptoHelperService;


        private readonly ILogger<UserController> _logger;
        public readonly IMapper _mapper;
        public readonly IEmailService _emailService;
        private IWebHostEnvironment _hostEnvironment;
        IUserService _userService;
        public UserController(IMapper mapper, IUserService modelService, IUserAuthService userAuthService , IEmailService emailService,
            IWebHostEnvironment hostEnvironment, ICryptoHelperService cryptoHelper)
        {
            _userService = modelService;
            _userAuthService = userAuthService;
            _mapper = mapper;
            _emailService = emailService;
            _hostEnvironment = hostEnvironment;
            _cryptoHelperService = cryptoHelper;

        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            model.Password = _cryptoHelperService.encrypt(model.Password);
            var response = _userAuthService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        //[Authorize]
        [HttpGet("Get/{UserId:int}")]
        public IActionResult Get(int UserId)
        {
            var UserList = _userService.GetAllByHotelId<User>(UserId);
           var list =  _mapper.Map<List< HMS.Domain.Model.User>>(UserList);
            return Ok(list);
        }

        //[Authorize]
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var UserList = _userService.GetById<User>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.User>>(UserList);
            return Ok(list);
        }

        [Authorize]
        [ActionFilter]
        [HttpPost("authenticateAdmin/{id:int}")]
        public IActionResult AuthenticateAdmin(int id)
        {
            var response = _userAuthService.AuthenticateAdmin(id);

            if (response == null)
                return BadRequest(new { message = "Admin Id is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [ActionFilter]
        [HttpPost]
       public IActionResult Post(User user)
        {
            var clientRequest = HttpContext.Request.Headers["Referer"];
            user.Password = _cryptoHelperService.encrypt(user.Password);
            _emailService.SendNewUser(user,"");
            _userService.Add(user);
            return Ok(new { Result = "Data Added" });
        }

        [HttpPost("PostAnonymousUser")]
        public IActionResult PostAnonymousUser(User user , string url)
        {
            //http://hmsangularbucket.s3-website.us-east-2.amazonaws.com
            string encodedUrl = WebUtility.HtmlEncode(url);
            if ( !_userService.CheckUserEmailAndMobile(user))
                return Ok(new { Result = "User email or Mobile number already in used." });
            user.Password = _cryptoHelperService.encrypt(user.Password);
            _userService.Add(user);
            _emailService.SendNewUser(user,url);
            return Ok(new { Result = "Data Added" });
        }


        [Authorize]
        [ActionFilter]
        [HttpPut]
        public IActionResult Put(User user)
        {
            _userService.Update(user);
            return Ok(new { Result = "Data Updated" });
        }


        [Authorize]
        [ActionFilter]
        [HttpGet("GetAllAdmin")]
        public IActionResult GetAllAdmin()
        {
            var UserList = _userService.GetAllAdmin<User>();
            var list = _mapper.Map<List<HMS.Domain.Model.User>>(UserList);
            return Ok(list);
        }


        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _userService.Delete(id);
            return Ok(new { Result = "deleted" });
        }
        //[Authorize]
        //[ActionFilter]
        //[HttpPost("AuthenticateAdmin")]
        //public IActionResult AuthenticateAdmin(int id)
        //{
        //    var response = _userAuthService.AuthenticateAdmin(id);

        //    if (response == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(response);
        //}

        [HttpPut("updatePassword")]
        public IActionResult UpdatePassword(string oldPwd, string newPwd, int userId)
        {
            oldPwd = _cryptoHelperService.encrypt(oldPwd);
            newPwd = _cryptoHelperService.encrypt(newPwd);
            var result = _userService.UpdatePassword(oldPwd, newPwd, userId);
            return Ok(new { Result = result });
        }

        [HttpPut("ForgetPassword")]
        public IActionResult ForgetPassword(string email, string url)
        {
            string encodedEmail = WebUtility.HtmlEncode(email);
            string encodedUrl = WebUtility.HtmlEncode(url);
            var result = _userService.ForgotPassword(encodedEmail,url);
            if(result.Length > 0)
            {
                _emailService.SendForgotPassword(new User { Email = email, ResetPasswordLink = result });
            }            
            return Ok(new { Result = true });
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(string password, string resetPasswordParam)
        {
            string encodedresetPasswordParam = WebUtility.HtmlEncode(resetPasswordParam);
            string encodedpassword = WebUtility.HtmlEncode(password);

            var paramArray = _cryptoHelperService.Decrypt(encodedpassword).Split('/');
            var email = paramArray[0];
            var date = DateTime.Parse(paramArray[1]);
            var result = (date.CompareTo(DateTime.UtcNow));
            if (result > 0)
                return Ok(new { Result = "Link expired" });


            // update password
            return Ok(new { Result = true });

        }

        [HttpPut("ForgetPasswordReset")]
        public IActionResult ForgetPasswordReset(string encryptedLink, string passwrod)
        {
            string link = WebUtility.HtmlEncode(encryptedLink);
            string password = WebUtility.HtmlEncode(passwrod);
            var result = _userService.ForgetPasswordReset(link, passwrod);
            return Ok(new { Result = result });
        }

    }
}
