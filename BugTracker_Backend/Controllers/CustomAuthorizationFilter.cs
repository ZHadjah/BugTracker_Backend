using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Net;

namespace BugTracker_Backend.Controllers
{
    public class CustomAuthorizationFilter : AuthorizeAttribute
    {
        //public void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        //{
        //    if (!context.HttpContext.Request.Headers.Authorization.IsNullOrEmpty())
        //    {
        //        var authToken = context.HttpContext.GetTokenAsync("access_token");
        //        var user = Token.ValidateToken(authToken);
        //        if (user == null)
        //        {
        //            context.HttpContext.Response = context.HttpContext.Request
        //                .CreateResponse(HttpStatusCode.Unauthorized, "Invalid Token");
        //        }
        //    }
        //    else
        //    {
        //        actionContext.Response = actionContext.Request
        //             .CreateResponse(HttpStatusCode.Unauthorized, "access token is required");
        //    }
        //}
    }
}
