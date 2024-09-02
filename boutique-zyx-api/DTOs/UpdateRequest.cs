using boutique_zyx_api.Validaciones;

namespace boutique_zyx_api.DTOs
{
    public class UpdateRequest
    {
        [PrimeraLetraMayusculaAttribute]
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string User { get; set; }
        public string PasswordHash { get; set; }
    }
}
