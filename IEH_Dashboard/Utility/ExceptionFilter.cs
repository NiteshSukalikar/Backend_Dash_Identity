namespace IEH_Dashboard.Utility
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;
    using IEH_Dashboard.Common.StaticConstants;
    using System.Net;

    /// <summary>
    /// Defines The ExceptionFilter
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// The OnException
        /// <param name="context">The context<see cref="ExceptionContext"/></param>
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/></param>
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(PrepareResponseObject(context));
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            base.OnException(context);
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The PrepareResponseObject
        /// <param name="context">The context<see cref="ExceptionContext"/></param>
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string PrepareResponseObject(ExceptionContext context)
        {
            Log.Error(context.ToString());
            return IEHMessages.GeneralException;
        }
    }
}
