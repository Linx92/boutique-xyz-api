using boutique_zyx_api.Entidades;

namespace boutique_zyx_api.Utilidades
{
    public class RolesUsuario
    {
        public static string RolUsuario(Usuario usuario)
        {
            string resultado = null;
            switch (usuario.Rol)
            {
                case 1:
                    resultado = "Encargado";
                    break;
                case 2:
                    resultado = "Vendedor";
                    break;
                case 3:
                    resultado = "Delivery";
                    break;
                case 4:
                    resultado = "Repartidor";
                    break;
            }

            return resultado;
        }
    }
}
