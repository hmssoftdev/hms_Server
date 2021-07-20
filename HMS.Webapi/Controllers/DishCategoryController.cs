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
    public class DishCategoryController:BaseController
    {
        private readonly ILogger<DishCategoryController> _logger;
        IDishCategoryService _dishCategoryService;
        public DishCategoryController(IMapper mapper, IDishCategoryService modelService) : base(mapper)
        {
            _dishCategoryService = modelService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var dishCategoryList = _dishCategoryService.GetAll<DishCategory>();
            var list = _mapper.Map<List<HMS.Domain.Model.DishCategory>>(dishCategoryList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(DishCategory dishCategory)
        {
            _dishCategoryService.Add(dishCategory);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult Put(DishCategory dishCategory)
        {
            _dishCategoryService.Update(dishCategory);
            return Ok("Data Updated");
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _dishCategoryService.Delete(id);
            return Ok("deleted");
        }

    }
}
