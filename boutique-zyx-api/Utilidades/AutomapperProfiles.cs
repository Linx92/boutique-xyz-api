using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;

namespace boutique_zyx_api.Utilidades
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<PedidoCreacionDTO, Pedido>()
                .ForMember(pedido => pedido.ProductoPedidos, opciones => opciones.MapFrom(MapProductoPedidos));
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<ProductoCreacionDTO,Producto>()
                .ForMember(producto => producto.Etiquetas, opciones => opciones.MapFrom(MapEtiquetasProducto));
            CreateMap<Pedido, PedidoDTO>()
                 .ForMember(pedido => pedido.ProductoPedidos, opciones => opciones.MapFrom(MapProductos));
            CreateMap<ProductoPedidoDTO, Pedido>().ReverseMap();
            CreateMap<PedidoEstadoDTO, Pedido>().ReverseMap();
            CreateMap<ProductoPedidoRespuestaDTO, Pedido>().ReverseMap();

            // User -> AuthenticateResponse
            CreateMap<Usuario, AuthenticateResponse>()
                .ForMember(usuario => usuario.Rol, opciones => opciones.MapFrom(MapRolUsuario)); ;

            // RegisterRequest -> User
            CreateMap<RegisterRequest, Usuario>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, Usuario>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
        private string MapRolUsuario(Usuario usuario, AuthenticateResponse authenticateResponse) 
        {
            return RolesUsuario.RolUsuario(usuario);
        }
        private List<ProductoPedidoDTO> MapProductos(Pedido pedido, PedidoDTO pedidoDTO)
        {
            var resultado = new List<ProductoPedidoDTO>();
            if (resultado == null) { return resultado; }

            foreach (var item in pedido.ProductoPedidos)
            {
                resultado.Add(new ProductoPedidoDTO() { SKU = item.SKU, Cantidad = item.Cantidad, NumeroPedido=item.NumeroPedido});
            }
            return resultado;
        }
        private List<ProductoPedido> MapProductoPedidos(PedidoCreacionDTO pedidoCreacionDTO, Pedido pedido)
        {
            var resultado = new List<ProductoPedido>();
            if (pedidoCreacionDTO == null) { return resultado; }

            foreach (var producto in pedidoCreacionDTO.Productos)
            {
                resultado.Add(new ProductoPedido() { SKU = producto.SKU,Cantidad=producto.Cantidad});
            }
            return resultado;
        }
        private string MapEtiquetasProducto(ProductoCreacionDTO productoCreacionDTO, Producto pedido)
        {
            string resultado = null;

            string etiqueta=null;
            foreach (var item in productoCreacionDTO.Etiquetas)
            {
                etiqueta = etiqueta + item + ",";
            }
            resultado = etiqueta;
            return resultado;
        }
    }
}
