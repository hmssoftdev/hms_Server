using AutoMapper;
using HMS.Domain;
using HMS.Service;
using HMS.Webapi.Helpers;
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
        Documents _documents;
        public DishController(IMapper mapper, IDishService modelService, IWebHostEnvironment webHostEnvironment, 
            IImageService imageService,Documents documents) :base(mapper)
        {
            _dishService = modelService;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
            _documents = documents;
        }

        [HttpGet("Get/{userId:int}")]
        public IActionResult Get(int userId)
        {
            var dishList = _dishService.GetAllByHotelId<Dish>(userId);
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
            if (dish.files != null && dish.files.Length > 0)
            {
                var fileName = $"{ dish.files.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage($"{dish.CreatedBy}/{fileName}", dish.files);
                dish.ImageUrl = $"{_documents.Url}{dish.CreatedBy}/{ fileName}";
            }
            
            _dishService.Add(dish);
            return Ok("Data Added");
        }

        [HttpPut]
        public IActionResult Put([FromForm]Dish dish)
        {
            if (dish.files!=null && dish.files.Length > 0)
            {
                var fileName = $"{ dish.files.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage($"{dish.UpdatedBy}/{fileName}", dish.files);
                dish.ImageUrl = $"{_documents.Url}{dish.UpdatedBy}/{ fileName}";
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
