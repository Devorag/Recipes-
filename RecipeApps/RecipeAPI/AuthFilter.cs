using CPUFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeAPI
{
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly int _requiredrole;

        public AuthFilter(int requiredrole)
        {
            _requiredrole = requiredrole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionKey = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (sessionKey != null && sessionKey.StartsWith("Bearer "))
            {
                sessionKey = sessionKey.Replace("Bearer ", "");
            }
            if (string.IsNullOrEmpty(sessionKey) || !IsAuthorized(sessionKey, _requiredrole, out var user))
            {
                context.Result = new UnauthorizedResult(); 
                return;
            }

            context.HttpContext.Items["AuthorizedUser"] = user;
        }

        private bool IsAuthorized(string sessionKey, int requiredrank, out bizUser user)
        {
            bool authorized = false;
            user = new bizUser();
            user.LoadBySessionKey();
            if (user.UserId > 0 && user.RoleRank >= requiredrank)
            {
                authorized = true;
            }
            return authorized;
        }
    }
}


