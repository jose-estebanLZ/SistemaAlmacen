using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaAlmacen.Filters;

public class FilterSession : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userId = context.HttpContext.Session.GetInt32("userId");

        if (userId == null)
        {
            context.Result = new RedirectResult("~/");
        }
    }
}