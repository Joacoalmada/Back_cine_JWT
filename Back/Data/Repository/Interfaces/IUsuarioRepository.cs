using Back.Data.Models;

namespace Back.Data.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario>? GetByIdAsync(int id);
        Task<Usuario>? GetByNameAsync(string name, string apellido);
        Task<bool> SaveAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}
