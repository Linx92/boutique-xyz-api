using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;

namespace boutique_zyx_api.Servicios.Contratos
{
    public interface IUsuarioService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
