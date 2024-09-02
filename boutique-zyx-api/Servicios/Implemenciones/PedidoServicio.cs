using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Repositorio.Implementaciones;
using boutique_zyx_api.Servicios.Contratos;

namespace boutique_zyx_api.Servicios.Implemenciones
{
    public class PedidoServicio:IPedidoServicio
    {
        private readonly IPedidoRepository pedidoRepository;
        public PedidoServicio(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }
        public async Task<EstructuraJsonEntity> CambioEstadoPedido(PedidoEstadoDTO pedidoEstadoDTO) 
        {
            try
            {
                var pedido = await pedidoRepository.CambioEstadoPedido(pedidoEstadoDTO);

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDTO> ObtenerDetallePedido(int numeroPedido)
        {
            try
            {
                var pedido = await pedidoRepository.ObtenerDetallePedido(numeroPedido);

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PedidoDTO>> ObtenerPedidos()
        {
            try
            {
                var pedido = await pedidoRepository.ObtenerPedidos() ;

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductoPedidoRespuestaDTO> CrearPedido(PedidoCreacionDTO pedidoCreacionDTO)
        {
            try
            {
                var producto = await pedidoRepository.CrearPedido(pedidoCreacionDTO);

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
