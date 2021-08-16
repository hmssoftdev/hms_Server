using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Hosting;
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
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<AdminController> _logger;
        IAdminService _AdminService;
        IImageService _imageService;

        public AdminController(IMapper mapper, IAdminService modelService, IWebHostEnvironment webHostEnvironment,
            IImageService imageService) : base(mapper)
        {
            _AdminService = modelService;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var AdminList = _AdminService.GetAll<Admin>();
            var list = _mapper.Map<List<HMS.Domain.Model.Admin>>(AdminList);
            return Ok(list);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var AdminList = _AdminService.GetById<Admin>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.Admin>>(AdminList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post([FromForm]Admin admin)
        {
            if (admin.files !=null && admin.files.Length > 0)
            {
                var fileName = $"{ admin.files.FileName}{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}";
                 _imageService.UploadImage(fileName, admin.files);
                admin.ImageUrl = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";
                
            }
            admin.SubscriptionStatus = 1;
            _AdminService.Add(admin);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult Put([FromForm]Admin admin)
        {
            if (admin.files !=null && admin.files.Length > 0)
            {
                var fileName = $"{ admin.files.FileName}{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}";

                _imageService.UploadImage(admin.files.FileName, admin.files);
                admin.ImageUrl = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ admin.files.FileName}";
                
            }
            _AdminService.Update(admin);
            return Ok("Data Updated");
        }
        [HttpPut("updateSubscription")]
        public IActionResult UpdateSubscription(Admin admin)
        {
            _AdminService.UpdateSubscriptionId(admin);
            return Ok("Data Updated");
        }

        [HttpDelete]
       public IActionResult DeleteById(int id)
        {
            _AdminService.Delete(id);          
            return Ok("deleted");
        }

    }
}
