using boutique_zyx_api.Authorization;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Servicios.Contratos;
using boutique_zyx_api.Servicios.Implemenciones;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace boutique_zyx_api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServicio pedidoServicio;
        public PedidoController(IPedidoServicio pedidoServicio)
        {
            this.pedidoServicio = pedidoServicio;

        }
        [Authorize]
        [HttpGet("{numeroPedido:int}", Name = "detallePedido")]
        public async Task<ActionResult<PedidoDTO>> Get(int numeroPedido)
        {

            var respuesta = await pedidoServicio.ObtenerDetallePedido(numeroPedido);

            return respuesta;
        }
        [Authorize]
        [HttpGet(Name = "pedidos")]
        public async Task<ActionResult<List<PedidoDTO>>> Get()
        {

            var respuesta = await pedidoServicio.ObtenerPedidos();

            return respuesta;
        }
        [Authorize("Encargado","Repartidor")]
        [HttpPut(Name = "ActualizaEstadoPedido")]
        public async Task<ActionResult> Put(PedidoEstadoDTO pedidoEstadoDTO)
        {

            var respuesta = await pedidoServicio.CambioEstadoPedido(pedidoEstadoDTO);
            if (respuesta.code == (int)HttpStatusCode.BadRequest) 
            {
                return BadRequest(respuesta.message);
            }

            return NoContent();
        }
        [Authorize("Vendedor")]
        [HttpPost(Name = "crearPedido")]
        public async Task<ActionResult> Post(PedidoCreacionDTO pedidoCreacionDTO)
        {

            var respuesta = await pedidoServicio.CrearPedido(pedidoCreacionDTO);

            if (respuesta.Cantidad > 0)
            {
                return BadRequest("La cantidad del producto solicitado" + respuesta.SKU + " no debe ser mayor al stock");
            }
            if (respuesta.Vendedor == 0) 
            {
                return BadRequest("No se pudo registrar al vendedor");
            }
            return CreatedAtRoute("detallePedido", new { numeroPedido = respuesta.NumeroPedido }, respuesta);
        }
    }
}
