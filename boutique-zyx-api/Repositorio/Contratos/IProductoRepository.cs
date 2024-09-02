using boutique_zyx_api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace boutique_zyx_api.Repositorio.Contratos
{
    public interface IProductoRepository
    {
        public Task<ProductoDTO> ObtenerProductoPorSKU(string sku);
        public Task<List<ProductoDTO>> ObtenerProducto();
        public Task<ProductoDTO> CrearProducto(ProductoCreacionDTO creacionProductoDTO);
        public Task<EstructuraJsonEntity> ActualizarCantidadProducto(string sku, ProductoCreacionDTO productoCreacionDTO);
    }
}
