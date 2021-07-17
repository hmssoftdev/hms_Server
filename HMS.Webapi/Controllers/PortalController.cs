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

    public class PortalController:BaseController
    {
        private readonly ILogger<PortalController> _logger;
        IPortalService _PortalService;
        public PortalController(IMapper mapper, IPortalService modelService) : base(mapper)
        {
            _PortalService = modelService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {

            var PortalList = _PortalService.GetAll<Hotel>();
            var list = _mapper.Map<List<HMS.Domain.Model.Hotel>>(PortalList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult post(Hotel portal)
        {
            _PortalService.Add(portal);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult put(Hotel portal)
        {
            _PortalService.Update(portal);
            return Ok("Data Updated");
        }
    }
}
