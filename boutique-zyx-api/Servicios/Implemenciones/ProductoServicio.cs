using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace boutique_zyx_api.Servicios.Implemenciones
{

    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepository productoRepositorio;
        public ProductoServicio(IProductoRepository productoRepositorio)
        {
            this.productoRepositorio = productoRepositorio;
        }
        public async Task<EstructuraJsonEntity> ActualizarCantidadProducto(string sku, ProductoCreacionDTO productoCreacionDTO)
        {

            try
            {
                var producto = await productoRepositorio.ActualizarCantidadProducto(sku,productoCreacionDTO);

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ProductoDTO>> ObtenerProducto()
        {
            try
            {
                var producto = await productoRepositorio.ObtenerProducto();

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductoDTO> ObtenerProductoPorSKU(string sku)
        {
            try
            {
                return await productoRepositorio.ObtenerProductoPorSKU(sku);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductoDTO> CrearProducto(ProductoCreacionDTO creacionProductoDTO) 
        {
            try
            {
                return await productoRepositorio.CrearProducto(creacionProductoDTO);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
