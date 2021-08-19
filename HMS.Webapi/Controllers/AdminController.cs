using AutoMapper;
using HMS.Domain;
using HMS.Service;
using HMS.Webapi.Helpers;
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
            if (admin.RestaurentLogoFile !=null && admin.RestaurentLogoFile.Length > 0)
            {
                var fileName = $"{ admin.RestaurentLogoFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                 _imageService.UploadImage(fileName, admin.RestaurentLogoFile);
                admin.RestaurentLogo = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.RestaurentSealFile != null && admin.RestaurentSealFile.Length > 0)
            {
                var fileName = $"{admin.RestaurentSealFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.RestaurentSealFile);
                admin.RestaurentSeal = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.SignatureFile != null && admin.SignatureFile.Length > 0)
            {
                var fileName = $"{admin.SignatureFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.SignatureFile);
                admin.Signature =$"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.UpiImageFile != null && admin.UpiImageFile.Length > 0)
            {
                var fileName = $"{admin.UpiImageFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.UpiImageFile);
                admin.UpiImage = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            admin.SubscriptionStatus = 1;
            _AdminService.Add(admin);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult Put([FromForm]Admin admin)
        {
            if (admin.RestaurentLogoFile != null && admin.RestaurentLogoFile.Length > 0)
            {
                var fileName = $"{ admin.RestaurentLogoFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.RestaurentLogoFile);
                admin.RestaurentLogo = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.RestaurentSealFile != null && admin.RestaurentSealFile.Length > 0)
            {
                var fileName = $"{admin.RestaurentSealFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.RestaurentSealFile);
                admin.RestaurentSeal = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.SignatureFile != null && admin.SignatureFile.Length > 0)
            {
                var fileName = $"{admin.SignatureFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.SignatureFile);
                admin.Signature = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

            }
            if (admin.UpiImageFile != null && admin.UpiImageFile.Length > 0)
            {
                var fileName = $"{admin.UpiImageFile.FileName}{DateTime.Now.ToString(DateHelper.DateFormat)}";
                _imageService.UploadImage(fileName, admin.UpiImageFile);
                admin.UpiImage = $"https://hmsdocuments.s3.us-east-2.amazonaws.com/{ fileName}";

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
