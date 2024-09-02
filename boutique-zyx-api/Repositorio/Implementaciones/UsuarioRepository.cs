using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.Repositorio.Contratos;
using boutique_zyx_api.Utilidades;

namespace boutique_zyx_api.Repositorio.Implementaciones
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private IJwtUtils _jwtUtils;
        public UsuarioRepository(ApplicationDbContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            this.context = context;
            this.mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = context.Usuarios.SingleOrDefault(x => x.User == model.User);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.PasswordHash, user.PasswordHash))
                throw new AppException("Usurio o Password incorrecto");

            // authentication successful
            var response = mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (context.Usuarios.Any(x => x.User == model.User))
                throw new AppException("Username '" + model.User + "' ya existe");

            if (model.Rol > 4)
            {
                throw new AppException("El rol que intenta asignar no existe");
            }

            // map model to new user object
            var user = mapper.Map<Usuario>(model);

            // hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            // save user
            context.Usuarios.Add(user);
            context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.User != user.User && context.Usuarios.Any(x => x.User == model.User))
                throw new AppException("Username '" + model.User + "' ya existe");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.PasswordHash))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            // copy model to user and save
            mapper.Map(model, user);
            context.Usuarios.Update(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            context.Usuarios.Remove(user);
            context.SaveChanges();
        }

        // helper methods

        private Usuario getUser(int id)
        {
            var user = context.Usuarios.Find(id);
            if (user == null) throw new KeyNotFoundException("Usuario no encontrado");
            return user;
        }
    }
    
}
