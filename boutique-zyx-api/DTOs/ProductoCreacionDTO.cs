using boutique_zyx_api.Entidades;
using boutique_zyx_api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace boutique_zyx_api.DTOs
{
    public class ProductoCreacionDTO
    {
        [PrimeraLetraMayusculaAttribute]
        [Required(ErrorMessage="El Nombre es requerido")]
        public string Nombre { get; set; }
        [PrimeraLetraMayusculaAttribute]
        [Required(ErrorMessage = "El Tipo es requerido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        public int Cantidad { get; set; }
        [PrimeraLetraMayusculaAttribute]
        [Required(ErrorMessage = "La unidad de medida es requerida")]
        public string UnidadMedida {  get; set; }
        public List<string> Etiquetas { get; set; }
    }
}
