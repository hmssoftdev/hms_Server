using AutoMapper;
using FluentEmail.Core;
using FluentEmail.Smtp;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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


        private readonly ILogger<UserController> _logger;
        public readonly IMapper _mapper;
        public readonly IEmailService _emailService;

        IUserService _userService;
        public UserController(IMapper mapper, IUserService modelService, IUserAuthService userAuthService , IEmailService emailService)
        {
            _userService = modelService;
            _userAuthService = userAuthService;
            _mapper = mapper;
            _emailService = emailService;

        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
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
            _userService.Add(user);
            return Ok(new { Result = "Data Added" });
        }

        [HttpPost("PostAnonymousUser")]
        public IActionResult PostAnonymousUser(User user)
        {
            _userService.Add(user);
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
            var result = _userService.UpdatePassword(oldPwd, newPwd, userId);
            return Ok(new { Result = result });
        }

        [HttpPut("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            _emailService.Send("fy5mubashir@gmail.com", "Dummy", $@"<h4>Verify Email</h4>
                         < p > Thanks for registering! </ p >"
                            );
            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage message = new MailMessage();
            //try

            //{

            //    // Prepare two email addresses

            //    MailAddress fromAddress = new MailAddress("fyowes99@gmail.com", "Feedback");
            //    MailAddress toAddress = new MailAddress("fy5mubashir@gmail.com", "You");

            //    // Prepare the mail message

            //    message.From = fromAddress;
            //    message.To.Add(toAddress);
            //    message.Subject = "Feedback";
            //    message.Body ="Test";
            //    // Set server details
            //    smtpClient.Host = "relay-hosting.secureserver.net";


            //    smtpClient.Send(message);
            //}

            //catch (Exception ex)
            //{

            //    // Display error message

            //   // statusLabel.Text = "Coudn't send the message!";
            //}

        

            //SmtpClient smtp = new SmtpClient
            //{
            //    //The address of the SMTP server (I'll take mailbox 126 as an example, which can be set according to the specific mailbox you use)
            //    Host = "smtp.126.com",
            //    UseDefaultCredentials = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    //Enter the user name and password of your sending SMTP server here
            //    Credentials = new NetworkCredential("fyowes99@gmail.com", "SKowais@786")
            //};
            ////Set default sending information
            //Email.DefaultSender = new SmtpSender(smtp);
            //var email = Email
            //  //Sender
            //  .From("fyowes99@gmail.com")
            //  //Addressee
            //  .To("fy5mubashir@gmail.com")
            //  //Message title
            //  .Subject("message title")
            //  //Email content
            //  .Body("email content");
            ////Determine whether the transmission is successful according to the transmission result
            //var result = email.Send();
            ////Or send it asynchronously
            ////await email.SendAsync();
            //if (result.Successful)
            //{
            //    //Send success logic
            //}
            //else
            //{
            //    //If the sending fails, you can pass the result.ErrorMessages View failure reasons
            //}
            return Ok();
        }
    }
}
