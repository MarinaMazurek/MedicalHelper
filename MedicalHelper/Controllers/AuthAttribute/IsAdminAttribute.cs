using MedicalHelper.Business.ServicesImplementations;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers.AuthAttribute
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userService = context
                .HttpContext
                .RequestServices
                .GetService(typeof(UserService)) as UserService;

            if (!userService.IsAdmin())
            {
                context.Result = new ForbidResult();
            }

            base.OnActionExecuted(context);
        }
    }
}
