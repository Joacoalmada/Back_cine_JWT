using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Back.Data.Service.Interfaces;

namespace Back.Data.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> EliminarUsuario(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<bool> GuardarUsuario(Usuario usuario)
        {
            return _repository.SaveAsync(usuario);
        }

        public Task<Usuario>? ObtenerUsuarioPorId(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Usuario>? ObtenerUsuarioPorNombre(string nombre, string apellido)
        {
            return _repository.GetByNameAsync(nombre, apellido);
        }

        public Task<List<Usuario>> ObtenerUsuarios()
        {
            return _repository.GetAllAsync();
        }
    }
}
