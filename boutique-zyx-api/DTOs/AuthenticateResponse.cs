using System.ComponentModel.DataAnnotations;

namespace boutique_zyx_api.DTOs
{
    public class AuthenticateResponse
    {
        public int CodigoTrabajador {  get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string User { get; set; }
        public string Rol {  get; set; }
        public string Token { get; set; }
    }
}
