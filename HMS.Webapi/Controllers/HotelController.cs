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
    public class HotelController:BaseController
    {

        private readonly ILogger<HotelController> _logger;
        IHotelTableService _HotelService;
        public HotelController(IMapper mapper, IHotelTableService modelService) : base(mapper)
        {
            _HotelService = modelService;
        }

        [HttpGet("Get/{UserId:int}")]
        public IActionResult Get(int UserId)
        {

            var HotelList = _HotelService.GetAllByHotelId<HotelTable>(UserId);
            var list = _mapper.Map<List<HMS.Domain.Model.HotelTable>>(HotelList);
            return Ok(list);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var HotelList = _HotelService.GetById<HotelTable>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.HotelTable>>(HotelList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult post(HotelTable hotel)
        {
            _HotelService.Add(hotel);
            return Ok(new { Result = "Data Added" });
        }
        [HttpPut]
        public IActionResult Put(HotelTable hotel)
        {
            _HotelService.Update(hotel);
            return Ok(new { Result= "Data Updated" });
        }
        [HttpPut("updateSeat")]
        public IActionResult UpdateSeat(HotelTable hotel)
        {
            _HotelService.UpdateSeatId(hotel);
            return Ok(new { Result = "Data Updated" });
        }
        [HttpPut("Booked")]
        public IActionResult UpdateBooked(HotelTable hotel)
        {
            _HotelService.UpdateBookedSeat(hotel);
            return Ok(new { Result = "Data Updated" });
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _HotelService.Delete(id);
            return Ok(new { Result = "deleted" });
        }
    }
}
