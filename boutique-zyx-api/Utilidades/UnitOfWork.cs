using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Repositorio.Implementaciones;
using boutique_zyx_api.Servicios.Contratos;
using boutique_zyx_api.Servicios.Implemenciones;

namespace boutique_zyx_api.Utilidades
{
    public static class UnitOfWork
    {

        public static void RegisterComponents(IServiceCollection services)
        {

            #region "Services"
            services.AddTransient<IProductoServicio, ProductoServicio>();
            services.AddTransient<IPedidoServicio, PedidoServicio>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion

            #region "Repositorio"
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

        }
    }
}
