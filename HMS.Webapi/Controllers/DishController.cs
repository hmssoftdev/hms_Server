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
    public class DishController : BaseController
    {


        private readonly ILogger<DishController> _logger;
        IDishService _dishService;
        public DishController(IMapper mapper, IDishService modelService) :base(mapper)
        {
            _dishService = modelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dishList = _dishService.GetAll<Dish>();
           var list =  _mapper.Map<List< HMS.Domain.Model.Dish>>(dishList);
            return Ok(list);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var dishList = _dishService.GetById<Dish>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.Dish>>(dishList);
            return Ok(list);
        }
       [HttpPost]
       public IActionResult post(Dish dish)
        {
            //Dish dish = new Dish();
            dish.Name = "chicken";
            return Ok(dish);
        }
    }
}
