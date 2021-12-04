using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Webapi.Controllers
{
    
    public class BusinessCategoryController:BaseController
    {
        private readonly ILogger<BusinessCategoryController> _logger;
        IBusinessCategoryService _BusinessCategoryService;
        public BusinessCategoryController(IMapper mapper, IBusinessCategoryService modelService) : base(mapper)
        {
            _BusinessCategoryService = modelService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var BusinessCategoryList = _BusinessCategoryService.GetAll<BusinessCategory>();
            var list = _mapper.Map<List<HMS.Domain.Model.BusinessCategory>>(BusinessCategoryList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(BusinessCategory businessCategory)
        {
            _BusinessCategoryService.Add(businessCategory);
            return Ok(new { Result = "Data Added" });
        }
        [HttpPut]
        public IActionResult Put(BusinessCategory businessCategory)
        {
            _BusinessCategoryService.Update(businessCategory);
            return Ok(new { Result = "Data Updated" });
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _BusinessCategoryService.Delete(id);
            return Ok(new { Result = "deleted" });
        }
    }
}
