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
        IHotelService _HotelService;
        public HotelController(IMapper mapper, IHotelService modelService) : base(mapper)
        {
            _HotelService = modelService;
        }

        [HttpGet("Get/{UserId:int}")]
        public IActionResult Get(int UserId)
        {

            var HotelList = _HotelService.GetAllByHotelId<Hotel>(UserId);
            var list = _mapper.Map<List<HMS.Domain.Model.Hotel>>(HotelList);
            return Ok(list);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var HotelList = _HotelService.GetById<Hotel>(id);
            var list = _mapper.Map<List<HMS.Domain.Model.Hotel>>(HotelList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult post(Hotel hotel)
        {
            _HotelService.Add(hotel);
            return Ok("Data Added");
        }
        [HttpPut]
        public IActionResult Put(Hotel hotel)
        {
            _HotelService.Update(hotel);
            return Ok("Data Updated");
        }
        [HttpPut("updateSeat")]
        public IActionResult updateSeat(Hotel hotel)
        {
            _HotelService.UpdateSeatId(hotel);
            return Ok("Data Updated");
        }
        [HttpPut("Booked")]
        public IActionResult UpdateBooked(Hotel hotel)
        {
            _HotelService.UpdateBookedSeat(hotel);
            return Ok("Data Updated");
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _HotelService.Delete(id);
            return Ok("deleted");
        }
    }
}
