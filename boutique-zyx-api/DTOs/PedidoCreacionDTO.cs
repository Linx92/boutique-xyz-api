using boutique_zyx_api.Servicios.Contratos;
using System.ComponentModel.DataAnnotations;

namespace boutique_zyx_api.DTOs
{
    public class PedidoCreacionDTO
    {
     
        [Required(ErrorMessage = "El campo FechaPedido es requerido")]//Siempre vamos a tener que recibir el valor del campo nombre
        public DateTime FechaPedido { get; set; }
        [Required(ErrorMessage = "El campo Vendedor es requerido")]
        public int Vendedor {  get; set; }
        public List<ProductoPedidoDTO> Productos { get; set; }

    }
}
