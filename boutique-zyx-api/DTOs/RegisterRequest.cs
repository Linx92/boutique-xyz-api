using boutique_zyx_api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace boutique_zyx_api.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [PrimeraLetraMayusculaAttribute]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Ingrese un correo electronico correcto")]
        public string CorreoElectronico { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required]
        public int Rol { get; set; }
    }
}
