namespace boutique_zyx_api.DTOs
{
    public class PedidoEstadoDTO
    {
        public int NumeroPedido { get; set; }
        public int Estado { get; set; } // Por atender, En proceso, En delivery, Recibido
        public int? Repartidor { get; set; }
    }
}
