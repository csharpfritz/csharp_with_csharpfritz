using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyCollectionSite;

public class InspectFilter : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Request.Path.Value?.Contains("api") ?? false)
        {
            var Logger = context.HttpContext.RequestServices.GetService<ILogger<InspectFilter>>();
            if (Logger == null) return;

            Logger.LogInformation("FROM FILTER!! Request for {path}", context.HttpContext.Request.Path);
            
        }
    }

}