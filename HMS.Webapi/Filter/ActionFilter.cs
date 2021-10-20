using HMS.Domain;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HMS.Webapi
{
    public class ActionFilter : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method == "POST" ||
                 context.HttpContext.Request.Method == "PUT")
            {
                var user = (User)context.HttpContext.Items["User"];
                if (context.ActionArguments.First().Value is IModel)
                {
                    var model = (IModel)context.ActionArguments.First().Value;
                    model.CreatedBy = user.Id;
                    model.UpdatedBy = user.Id;
                }
            }
            // our code before action executes
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            var result = continuation();

            result.Wait();

            System.Diagnostics.Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            return result;
        }


    }
}