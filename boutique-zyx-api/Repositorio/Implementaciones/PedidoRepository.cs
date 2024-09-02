using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Servicios.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace boutique_zyx_api.Repositorio.Implementaciones
{
    public class PedidoRepository:IPedidoRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IProductoServicio productoServicio;
        public PedidoRepository(ApplicationDbContext context, IMapper mapper, IProductoServicio productoServicio)
        {
            this.context = context;
            this.mapper = mapper;
            this.productoServicio = productoServicio;
        }
        public async Task<PedidoDTO> ObtenerDetallePedido(int numeroPedido)
        {
            var pedido = await context.Pedidos
                .Include(x => x.ProductoPedidos).
                FirstOrDefaultAsync(x => x.NumeroPedido == numeroPedido);
            if (pedido == null)
            {
                return null;
            }
            var resultado =  mapper.Map<PedidoDTO>(pedido);
            return resultado;
        }
        public async Task<List<PedidoDTO>> ObtenerPedidos()
        {
            var pedido = await context.Pedidos.AsQueryable()
                .Include(x => x.ProductoPedidos)
                .ToListAsync();

            return mapper.Map<List<PedidoDTO>>(pedido);
        }
        public async Task<EstructuraJsonEntity> CambioEstadoPedido(PedidoEstadoDTO pedidoEstadoDTO) 
        {
            var pedido = await context.Pedidos.FirstOrDefaultAsync(x => x.NumeroPedido==pedidoEstadoDTO.NumeroPedido);

            if (pedido == null)
            {
                return new EstructuraJsonEntity { code=400, message="Pedido no encontrado"};
            }

            if (pedido.Estado>=pedidoEstadoDTO.Estado)
            {
                return new EstructuraJsonEntity { code = 400, message = "El pedido no puede actualizarse a un estado actual o anterior" };
            }
            
            pedido = mapper.Map(pedidoEstadoDTO, pedido);
            switch (pedido.Estado)
            {
                case 2:
                    pedido.FechaRecepcion = DateTime.Now;
                    break;
                case 3:
                    pedido.FechaDespacho = DateTime.Now;
                    var repartidor = await context.Usuarios
                        .FirstOrDefaultAsync(x => x.CodigoTrabajador == pedidoEstadoDTO.Repartidor && x.Rol==4);
                    if (repartidor is null) 
                    {
                        return new EstructuraJsonEntity { code = 400, message = "Debe asignar un repartidor" };
                    }
                    break;
                case 4:
                    pedido.FechaEntrega = DateTime.Now;
                    break;

            }
            await context.SaveChangesAsync();
            return new EstructuraJsonEntity { code = 202, message = "Estado de pedido actualizado" };
        }
        
        public async Task<ProductoPedidoRespuestaDTO> CrearPedido(PedidoCreacionDTO pedidoCreacionDTO)
        {

            var pedido = mapper.Map<Pedido>(pedidoCreacionDTO);
            pedido.NumeroPedido = await ObtenerUltimoPedido() + 1;
            pedido.Estado = (int)Estados.Por_atender;
            var vendedor = await context.Usuarios
                       .FirstOrDefaultAsync(x => x.CodigoTrabajador == pedidoCreacionDTO.Vendedor && x.Rol == 2);
            if (vendedor is null)
            {
                return new ProductoPedidoRespuestaDTO { Vendedor = 0 };
            }

            foreach (var item in pedido.ProductoPedidos) 
            {
                item.NumeroPedido = pedido.NumeroPedido;
                var producto = await context.Productos.FirstOrDefaultAsync(x => x.SKU == item.SKU);

                if (producto.Cantidad < item.Cantidad) 
                {
                    return new ProductoPedidoRespuestaDTO { Cantidad=item.Cantidad, SKU=item.SKU};
                }
                producto.Cantidad = producto.Cantidad - item.Cantidad;
            }
            context.Add(pedido);
            await context.SaveChangesAsync();

            var productoPedidoDTO = mapper.Map<ProductoPedidoRespuestaDTO>(pedido);
            return productoPedidoDTO;

        }
        private async Task<int> ObtenerUltimoPedido()
        {
            var pedido = await context.Pedidos.OrderByDescending(p => p.NumeroPedido)
                                .FirstOrDefaultAsync();
            if (pedido is null) //Funciona cuando no hay registros en la tabla
            {
                return 0;
            }
            return pedido.NumeroPedido;

        }
        enum Estados
        {
            Por_atender = 1, En_proceso = 2, En_delivery = 3, Recibido = 4
        }
    }
}
