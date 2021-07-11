using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        IUserService _userService;
        public UserController(IMapper mapper, IUserService modelService, IUserAuthService userAuthService)
        {
            _userService = modelService;
            _userAuthService = userAuthService;
            _mapper = mapper;

        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userAuthService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var userList = _userService.GetAll<User>();
           var list =  _mapper.Map<List< HMS.Domain.Model.User>>(userList);
            return Ok(list);
        }

        [Authorize]
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var dishList = _userService.GetById<User>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.User>>(dishList);
            return Ok(list);
        }

        [Authorize]
        [HttpPost]
       public IActionResult Post(User user)
        {
            _userService.Add(user);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(User user)
        {
            _userService.Update(user);
            return Ok();
        }
    }
}
