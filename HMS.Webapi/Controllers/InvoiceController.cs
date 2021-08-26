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
    public class InvoiceController : BaseController
    {
        private IInvoice _invoiceService;
        private IAdminService _adminService;
        private IUserService _userService;
        private IDishService _dishService;


        private readonly ILogger<InvoiceController> _logger;
        public readonly IMapper _mapper;

        
        public InvoiceController(IMapper mapper,  IInvoice invoiceService, IAdminService adminService,
            IUserService userService, IDishService dishService):base(mapper)
        {
            _adminService = adminService;
            _userService = userService;
            _dishService = dishService;
            _invoiceService = invoiceService;
            
           
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var admin = _adminService.GetById<Admin>(41);
            var user = _userService.GetById<User>(1);
            var dish = _dishService.GetById<Dish>(1);
            _invoiceService.GetInvoice(admin.First(),user.First());
            return Ok();
        }

        
        
        



    }
}
