using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ChatApi.Filter
{
    public class AuthorizeUserType : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredUserType;

        public AuthorizeUserType(string requiredUserType)
        {
            _requiredUserType = requiredUserType;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userClaims = context.HttpContext.User.Claims;
            var userType = userClaims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType == null || userType != _requiredUserType)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
