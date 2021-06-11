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
    public class StateCityController:BaseController
    {
        private readonly ILogger<StateCityController> _logger;
        IMasterService _MasterService;
        public StateCityController(IMapper mapper, IMasterService modelService) : base(mapper)
        {
            _MasterService = modelService;
        }

        [HttpGet("GetCity")]
        public IActionResult GetCity()
        {
            var CityMasterList = _MasterService.GetAllCity<CityMaster>();
            var list = _mapper.Map<List<HMS.Domain.Model.CityMaster>>(CityMasterList);
            return Ok(list);
        }

        [HttpGet("GetState")]
        public IActionResult GetState()
        {
            var StateMasterList = _MasterService.GetAllState<StateMaster>();
            var list = _mapper.Map<List<HMS.Domain.Model.StateMaster>>(StateMasterList);
            return Ok(list);
        }

    }
}
