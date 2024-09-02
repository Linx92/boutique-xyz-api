using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace boutique_zyx_api.Entidades
{
    public class Usuario 
    {
        public int CodigoTrabajador { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string User {  get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public int Rol { get; set; } // Encargado, Vendedor, Delivery, Repartidor
        enum Roles
        {
            Encargado = 1, 
            Vendedor = 2,  
            Delivery = 3,  
            Repartidor = 4 
        }
    }

}
