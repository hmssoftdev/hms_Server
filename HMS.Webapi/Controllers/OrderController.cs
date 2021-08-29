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
        [HttpPost]
        public IActionResult Post(DishOrder dishOrder)
        {
            _orderService.Add(dishOrder);
            return Ok();
        }

    }
}
