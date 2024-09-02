using System.ComponentModel.DataAnnotations;

namespace boutique_zyx_api.DTOs
{
    public class AuthenticateRequest
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
