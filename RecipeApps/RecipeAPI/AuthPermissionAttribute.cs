namespace RecipeAPI
{
    using Microsoft.AspNetCore.Mvc;
    using RecordKeeperAPI;
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
