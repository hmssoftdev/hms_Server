﻿using AutoMapper;
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
    public class UserConfigController : BaseController
    {
        private readonly ILogger<UserConfigController> _logger;
        IUserConfigService _UserConfigService;
        public UserConfigController(IMapper mapper, IUserConfigService modelService) : base(mapper)
        {
            _UserConfigService = modelService;
        }

        public object UserConfigdList { get; private set; }

        [HttpGet("Get/{UserId:int}")]
        public IActionResult Get(int UserId)
        {
           
            var UserConfigList = _UserConfigService.GetAllByHotelId<UserConfig>(UserId);
            var list = _mapper.Map<List<HMS.Domain.Model.UserConfig>>(UserConfigList);
            return Ok(list);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var UserConfigList = _UserConfigService.GetById<UserConfig>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.UserConfig>>(UserConfigList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(UserConfig userConfig)
        {
            _UserConfigService.Add(userConfig);
            return Ok(new { Result = "Data Added" });
        }


        [HttpPut]
        public IActionResult Put(UserConfig userConfig)
        {
            _UserConfigService.Update(userConfig);
            return Ok(new { Result = "Data Updated" });
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _UserConfigService.Delete(id);
            return Ok(new { Result = "deleted" });
        }
    }
}
