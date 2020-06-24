using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ExampleSupportTicketSystem.Api.Filters
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)]
    public class CustomAuthorizeScope : ActionFilterAttribute
    {
        public string AllowedScope { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var principal = context.HttpContext.User as ClaimsPrincipal;
            
            // Ensure the User Context is Authenticate.
            if (principal.Identity.IsAuthenticated)
            {
                // check to see if the Identity has access to the claim.
                Claim containsClaim = (principal.Claims.Where(p => p.Type == "scope" && p.Value == AllowedScope).FirstOrDefault());

                // We have located the claim needed
                if (containsClaim != null)
                {
                    base.OnActionExecuting(context);
                }
                else
                {
                    // Not authorized, create a 401 response and end request.
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new UnauthorizedObjectResult("Credentials or Scope Invalid");
                }

            }
        }
    }
}
