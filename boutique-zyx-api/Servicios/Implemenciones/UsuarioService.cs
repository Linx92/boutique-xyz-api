using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Servicios.Contratos;
using boutique_zyx_api.Utilidades;

namespace boutique_zyx_api.Servicios.Implemenciones
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            return usuarioRepository.Authenticate(model);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarioRepository.GetAll();
        }

        public Usuario GetById(int id)
        {
            return usuarioRepository.GetById(id);
        }

        public void Register(RegisterRequest model)
        {
            usuarioRepository.Register(model);
        }

        public void Update(int id, UpdateRequest model)
        {
            usuarioRepository.Update(id, model);
        }

        public void Delete(int id)
        {
            usuarioRepository.Delete(id);
        }

        // helper methods

    }
}
