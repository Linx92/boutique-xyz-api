using boutique_zyx_api.Entidades;

namespace boutique_zyx_api.DTOs
{
    public class ProductoDTO
    {
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Etiquetas { get; set; } // Separados por coma
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public List<ProductoPedidoDTO> ProductoPedidos { get; set; }
    }
}
