using boutique_zyx_api.DTOs;

namespace boutique_zyx_api.Repositorio.Contratos
{
    public interface IPedidoRepository
    {
        public Task<List<PedidoDTO>> ObtenerPedidos();
        public Task<PedidoDTO> ObtenerDetallePedido(int numeroPedido);
        public Task<EstructuraJsonEntity> CambioEstadoPedido(PedidoEstadoDTO pedidoEstadoDTO);
        public Task<ProductoPedidoRespuestaDTO> CrearPedido(PedidoCreacionDTO pedidoCreacionDTO);

    }

}
