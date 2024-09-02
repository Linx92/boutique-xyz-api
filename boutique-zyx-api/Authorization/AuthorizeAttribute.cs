using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Utilidades;

namespace boutique_zyx_api.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;

        // Constructor opcional para recibir roles
        public AuthorizeAttribute(params string[] roles)
        {
            this.roles = roles ?? new string[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Usuario)context.HttpContext.Items["Usuario"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            // Check if user has the required roles
            if (roles.Any() && !roles.Contains(RolesUsuario.RolUsuario(user)))
            {
                context.Result = new JsonResult(new { message = "Forbidden - No tienes el rol requerido" })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return;
            }

        }
    }
}
