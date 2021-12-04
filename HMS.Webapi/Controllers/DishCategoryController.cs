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
        [HttpGet("Get/{userId:int}")]
        public IActionResult Get(int userId)
        {
            var dishCategoryList = _dishCategoryService.GetAllByHotelId<DishCategory>(userId);
            var list = _mapper.Map<List<HMS.Domain.Model.DishCategory>>(dishCategoryList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(DishCategory dishCategory)
        {
            _dishCategoryService.Add(dishCategory);
            return Ok(new { Result = "Data Added" });
        }
        [HttpPut]
        public IActionResult Put(DishCategory dishCategory)
        {
            _dishCategoryService.Update(dishCategory);
            return Ok(new { Result = "Data Updated" });
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _dishCategoryService.Delete(id);
            return Ok(new { Result = "deleted" });
        }

    }
}
