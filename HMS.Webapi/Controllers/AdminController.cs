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
    public class AdminController:BaseController
    {
        private readonly ILogger<AdminController> _logger;
        IAdminService _dishService;
        public AdminController(IMapper mapper, IAdminService modelService) : base(mapper)
        {
            _dishService = modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var AdminList = _dishService.GetAll<Admin>();
            var list = _mapper.Map<List<HMS.Domain.Model.Admin>>(AdminList);
            return Ok(list);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var AdminList = _dishService.GetById<Admin>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.Admin>>(AdminList);
            return Ok(list);
        }
    }
}
