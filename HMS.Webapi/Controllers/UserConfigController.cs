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
        private readonly ILogger<UseConfigController> _logger;
        IUserConfigService _dishService;
        public UserConfigController(IMapper mapper, IUserConfigService modelService) : base(mapper)
        {
            _dishService = modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
            //var dishList = _dishService.GetAll<UserConfig>();
            //var list = _mapper.Map<List<HMS.Domain.Model.Dish>>(dishList);
            //return Ok(list);
        }
    }
}
