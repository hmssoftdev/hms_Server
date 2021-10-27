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
        [HttpGet("Get/status/{OrderId:int}")]
        public IActionResult GetStatusByOrderId(int OrderId)
        {
            var statusList = _orderService.GetStatusByOrderId(OrderId);
            var list = _mapper.Map<List<HMS.Domain.Model.OrderStatus>>(statusList);
            return Ok(list);
        }
        [HttpGet("Get/orderitem/{OrderId:int}")]
        public IActionResult GetOrderItemByOrderId(int OrderId)
        {
            var orderList = _orderService.GetOrderItemByOrderId(OrderId);
            var list = _mapper.Map<List<HMS.Domain.Model.OrderItem>>(orderList);
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
        [HttpPut]
        public IActionResult Put(DishOrder dishOrder)
        {
            _orderService.Update(dishOrder);
            return Ok();
        }
        [HttpPost("Addorder")]
        public IActionResult Post (OrderItem item)
        {
            _orderService.Add(item);
            return Ok("Item Added");
        }
        [HttpPut("OrderUpdate")]
        public IActionResult Update (OrderItem item)
        {
            _orderService.Update(item);
            return Ok("item updated");
        }

        [HttpPut("Put/ReleaseTable")]
        public IActionResult ReleaseOrderTable(int id)
        {
            _orderService.ReleaseTable(id);
            return Ok();
        }
    }
}
