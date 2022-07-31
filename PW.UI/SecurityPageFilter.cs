using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PW.UI
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _iauthhelper;

        public SecurityPageFilter(IAuthHelper iauthhelper)
        {
            _iauthhelper = iauthhelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

            var userRole = _iauthhelper.CurrentAccountRole();

            //if (!string.IsNullOrWhiteSpace(userRole))
            //{
            //    context.HttpContext.Response.Redirect("/AdminPanel");
            //}

        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }
    }
}