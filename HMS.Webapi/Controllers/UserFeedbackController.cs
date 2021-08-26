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
    public class UserFeedbackController:BaseController
    {
        private readonly ILogger<UserFeedbackController> _logger;
        IUserFeedbackService _UserFeedbackService;
        public UserFeedbackController(IMapper mapper, IUserFeedbackService modelService) : base(mapper)
        {
            _UserFeedbackService = modelService;
        }
        [HttpGet("Get/{UserId:int}")]
        public IActionResult Get(int UserId)
        {
            var UserFeedbackList = _UserFeedbackService.GetAllByHotelId<UserFeedback>(UserId);
            var list = _mapper.Map<List<HMS.Domain.Model.UserFeedback>>(UserFeedbackList);
            return Ok(list);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var UserFeedbackList = _UserFeedbackService.GetById<UserFeedback>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.UserFeedback>>(UserFeedbackList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(UserFeedback userFeedback)
        {
            _UserFeedbackService.Add(userFeedback);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult Put(UserFeedback userFeedback)
        {
            _UserFeedbackService.Update(userFeedback);
            return Ok("Data Updated");
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _UserFeedbackService.Delete(id);
            return Ok("deleted");
        }
    }
}
