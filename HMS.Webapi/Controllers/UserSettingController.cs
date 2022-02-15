using AutoMapper;
using HMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Webapi.Controllers
{
    [Route("[controller]")]
    public class UserSettingController: BaseController
    {
        public UserSettingController(IMapper mapper ) : base(mapper)
        {
            
        }

        [HttpGet]
        public IActionResult Get(int UserId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(UserSettings userSettings )
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserSettings userSettings)
        {
            return Ok();
        }
    }
}
