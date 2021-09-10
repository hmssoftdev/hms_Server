using AutoMapper;
using HMS.Domain;
using HMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HMS.Webapi.Controllers
{
    [Route("[controller]")]
    public class OrderController : BaseController
    {
        private readonly ILogger<OrderController> _logger;
        IOrderService _orderService;
        
        public OrderController(IMapper mapper, IOrderService orderService
           ) : base(mapper)
        {
            _orderService = orderService;
        }
        [HttpGet("Get/{userId:int}")]
        public IActionResult Get(int userId)
        {
            var orderList = _orderService.GetAllByHotelId<DishOrder>(userId);
            var list = _mapper.Map<List<HMS.Domain.Model.DishOrder>>(orderList);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(DishOrder dishOrder)
        {
            
            _orderService.Add(dishOrder);
            return Ok();
        }
        [HttpPost("Post/{AddStatus}")]
        public IActionResult Post (OrderStatus status)
        {
            _orderService.AddStatus(status);
            return Ok();
        }

    }
}
