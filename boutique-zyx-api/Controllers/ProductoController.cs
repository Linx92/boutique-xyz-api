using AutoMapper;
using boutique_zyx_api.Authorization;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace boutique_zyx_api.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController:ControllerBase
    {
        private readonly IProductoServicio productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            this.productoServicio = productoServicio;
        }
        [Authorize("Encargado")]
        [HttpPost(Name = "crearProducto")]
        public async Task<ActionResult> Post(ProductoCreacionDTO creacionProductoDTO) 
        {

            var respuesta = await productoServicio.CrearProducto(creacionProductoDTO);
            if (respuesta == null) 
            {
                return BadRequest("El producto que desea registrar ya existe");
            }
            return Ok(new { message = "El producto se registró correctamente" });
        }
        [Authorize("Encargado","Vendedor")]
        [HttpGet("{sku}", Name = "obtenerProductoporSku")]
        public async Task<ActionResult<ProductoDTO>> Get(string sku)
        {

            return await productoServicio.ObtenerProductoPorSKU(sku);
        }
        [Authorize("Encargado", "Vendedor")]
        [HttpGet( Name = "obtenerProducto")]
        public async Task<ActionResult<List<ProductoDTO>>> Get()
        {

            return await productoServicio.ObtenerProducto();
        }
    }
}
