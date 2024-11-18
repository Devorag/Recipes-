namespace RecipeAPI
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class AuthPermissionAttribute : TypeFilterAttribute
    {
        public AuthPermissionAttribute(int requiredPermissionLevel)
            : base(typeof(AuthFilter))
        {
            Arguments = new object[] { requiredPermissionLevel };
        }
    }

}
