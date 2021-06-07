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
    public class UserConfigController : BaseController
    {
        private readonly ILogger<UserConfigController> _logger;
        IUserConfigService _UserConfigService;
        public UserConfigController(IMapper mapper, IUserConfigService modelService) : base(mapper)
        {
            _UserConfigService = modelService;
        }

        public object UserConfigdList { get; private set; }

        [HttpGet]
        public IActionResult Get()
        {
           
            var UserConfigList = _UserConfigService.GetAll<UserConfig>();
            var list = _mapper.Map<List<HMS.Domain.Model.UserConfig>>(UserConfigList);
            return Ok(list);
        }
    }
}
