namespace IEH_Dashboard.Utility
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using IEH_Dashboard.ViewModel.Shared;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines The LogApiFilter
    /// </summary>
    public class LogApiFilter : IAsyncActionFilter
    {
        /// <summary>
        /// The OnActionExecutionAsync
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutingContext"/></param>
        /// </summary>
        /// <param name="requestContext">The requestContext<see cref="ActionExecutingContext"/></param>
        /// <param name="next">The next<see cref="ActionExecutingContext"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext requestContext, ActionExecutionDelegate next)
        {
            // Do something before the action executes.
            ActionExecutedContext resultContext = await next();

            AuditLogVM auditLogVM = new AuditLogVM();

            if (resultContext.Exception != null)
            {
                // Exception thrown by action or action filter.
                auditLogVM.Response = resultContext.Exception.Message;
            }
            else
            {
                auditLogVM.Response = "Success";
            }

            if (resultContext.Canceled == true)
            {
                auditLogVM.Response = resultContext.Canceled.ToString();
            }

            var abc = requestContext.HttpContext.Items.ContainsKey("Payload");

            auditLogVM.Payload = requestContext.HttpContext.Items.ContainsKey("Payload") ? requestContext.HttpContext.Items["Payload"].ToString() : "";
            auditLogVM.Endpoint = requestContext.HttpContext.Request.Path;
            auditLogVM.Method = requestContext.HttpContext.Request.Method;
            auditLogVM.CreatedBy = requestContext.HttpContext.Items.ContainsKey("CreatedBy") ? Convert.ToInt64(requestContext.HttpContext.Items["CreatedBy"]) : requestContext.HttpContext.Request.Headers.ContainsKey("userid") ? Convert.ToInt64(requestContext.HttpContext.Request.Headers["userid"].ToString()) : 0;
            auditLogVM.CreatedOn = requestContext.HttpContext.Request.Headers.ContainsKey("createdOn") ? Convert.ToInt64(requestContext.HttpContext.Request.Headers["createdOn"].ToString()) : 0;

            Controllers.DashboardController controller = requestContext.Controller as Controllers.DashboardController;

            controller.AuditApi(auditLogVM);
        }
    }
}
