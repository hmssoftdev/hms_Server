using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HMS.Webapi.Controllers
{
    public class ErrorController : ControllerBase
    {

        public ErrorController(IMapper mapper)
        {

        }

        [HttpGet]
        [Route("/errors")]
        public IActionResult Error() => Problem();

        [HttpGet]
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            //if (webHostEnvironment.EnvironmentName != "Development")
            //{
            //    throw new InvalidOperationException(
            //        "This shouldn't be invoked in non-development environments.");
            //}

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
    }
}