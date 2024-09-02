using boutique_zyx_api.Entidades;

namespace boutique_zyx_api.DTOs
{
    public class ProductoPedidoDTO
    {
        public int NumeroPedido { get; set; }
        public string SKU { get; set; }
        public int Cantidad { get; set; }

    }
}
