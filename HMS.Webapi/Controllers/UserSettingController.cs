using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Webapi.Controllers
{
    [Route("[controller]")]
    public class UserSettingController: BaseController
    {
        private IUserSettingService _userSettingService;

        public UserSettingController(IMapper mapper, IUserSettingService userSettingService) : base(mapper)
        {
            _userSettingService = userSettingService;

        }

        [HttpGet]
        public IActionResult Get(int UserId)
        {
           var settings =  _userSettingService.GetById<UserSettings>(UserId);
           var list =  _mapper.Map<List< HMS.Domain.Model.UserSettings>>(settings);
            return Ok(list.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Post(UserSettings userSettings )
        {
            _userSettingService.Add(userSettings);
            return Ok(new {Result = "Date Added"});
        }

        [HttpPut]
        public IActionResult Put(UserSettings userSettings)
        {
            _userSettingService.Update(userSettings);
            return Ok(new { Result = "Date updated" });
        }
    }
}
