using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Webapi.Controllers
{
    [ApiController]
    //[Authorize]
    //[ActionFilter]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        public readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

      

    }
}
