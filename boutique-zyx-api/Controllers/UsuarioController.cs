using AutoMapper;
using boutique_zyx_api.Authorization;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Servicios.Contratos;
using boutique_zyx_api.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace boutique_zyx_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController:ControllerBase
    {
        private IUsuarioService usuarioService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsuarioController(
            IUsuarioService usuarioService,
            IOptions<AppSettings> appSettings)
        {
            this.usuarioService = usuarioService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = usuarioService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public IActionResult Registrar(RegisterRequest model)
        {
            usuarioService.Register(model);
            return Ok(new { message = "Registro exitoso" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = usuarioService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = usuarioService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            usuarioService.Update(id, model);
            return Ok(new { message = "Se ha actualizado al usuario con éxito" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            usuarioService.Delete(id);
            return Ok(new { message = "Se ha eliminado al usuario con éxito" });
        }
    }
}
