using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Webapi.Controllers
{
    [Route("[controller]")]
    public class DishController : BaseController
    {
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DishController> _logger;
        IDishService _dishService;
        IImageService _imageService;
        public DishController(IMapper mapper, IDishService modelService, IWebHostEnvironment webHostEnvironment, 
            IImageService imageService) :base(mapper)
        {
            _dishService = modelService;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
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
       public IActionResult Post([FromForm] Dish dish)
        {
            if (dish.files.Length > 0)
            {
               if(_imageService.UploadImage(dish.files.FileName, dish.files))
                {
                    dish.ImageUrl = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ dish.files.FileName}";
                }
            }
            
            _dishService.Add(dish);
            return Ok("Data Added");
        }

        [HttpPut]
        public IActionResult Put(Dish dish)
        {
            if (dish.files.Length > 0)
            {
                if (_imageService.UploadImage(dish.files.FileName, dish.files))
                {
                    dish.ImageUrl = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ dish.files.FileName}";
                }
            }
            _dishService.Update(dish);
            return Ok("Data Updated");
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _dishService.Delete(id);
            return Ok("deleted");
        }

    }
}
