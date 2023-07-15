using BugTracker_Backend.Configurations;
using BugTracker_Backend.Services.Interfaces;

namespace BugTracker_Backend.Middlewares
{
    public class JwtMiddleware
    {
        public JwtMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context, JwtConfig config, IBTAuthenticationService service)
        {
            //Split the string and grab the token
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token != null)
            {
                var claims = service.ValidateToken(token, config.Secret);
                if (claims.Any())
                {
                    context.User.AddIdentity(new System.Security.Claims.ClaimsIdentity(claims));
                }
            }
            await _request(context);
        }
        private readonly RequestDelegate _request;
    }
}
