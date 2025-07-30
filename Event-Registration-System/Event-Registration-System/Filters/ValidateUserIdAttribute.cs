using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Event_Registration_System.Filters
{
    public class ValidateUserIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out _))
            {
                context.Result = new JsonResult(ApiResponse.Unauthorized("Not Authorized."))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            base.OnActionExecuting(context);
        }
    }
}
