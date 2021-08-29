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
            var order = new DishOrder()
            {
                AdminId = 1 ,DeliveryTotal = 100,GrossTotal = 200,ItemCount = 2 ,ItemTotal = 2 ,UserId = 3 ,
                OrderItems = new List<OrderItem> 
                { new OrderItem { GstCompliance = 2 ,GstPrice = 1 ,Price = 12,ProductId =2,Quantity = 2} , new OrderItem { GstCompliance = 2, GstPrice = 1, Price = 12, ProductId = 2, Quantity = 2 } },
                OrderStatus = new List<OrderStatus> { new OrderStatus { Status = 1 } }
            };
            _orderService.Add(order);
            return Ok();
        }

    }
}
