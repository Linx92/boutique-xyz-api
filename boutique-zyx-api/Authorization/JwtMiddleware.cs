﻿using boutique_zyx_api.Servicios.Contratos;
using boutique_zyx_api.Utilidades;

namespace boutique_zyx_api.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUsuarioService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Usuario"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
