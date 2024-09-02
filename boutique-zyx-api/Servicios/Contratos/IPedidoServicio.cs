using boutique_zyx_api.DTOs;

namespace boutique_zyx_api.Servicios.Contratos
{
    public interface IPedidoServicio
    {
        public Task<List<PedidoDTO>> ObtenerPedidos();
        public Task<PedidoDTO> ObtenerDetallePedido(int numeroPedido);
        public Task<EstructuraJsonEntity> CambioEstadoPedido(PedidoEstadoDTO pedidoEstadoDTO);
        public Task<ProductoPedidoRespuestaDTO> CrearPedido(PedidoCreacionDTO pedidoCreacionDTO);

    }
}
