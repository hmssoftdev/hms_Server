using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Webapi.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController
    {


        private readonly ILogger<UserController> _logger;
        IUserService _userService;
        public UserController(IMapper mapper, IUserService modelService) :base(mapper)
        {
            _userService = modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userList = _userService.GetAll<User>();
           var list =  _mapper.Map<List< HMS.Domain.Model.User>>(userList);
            return Ok(list);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var dishList = _userService.GetById<User>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.User>>(dishList);
            return Ok(list);
        }
       [HttpPost]
       public IActionResult Post(User user)
        {
            _userService.Add(user);
            return Ok("Data Added");
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            _userService.Update(user);
            return Ok("Data Updated");
        }
    }
}
