using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Data.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CineDBContext _context;

        public UsuarioRepository(CineDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = GetByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(await usuario);
                return await _context.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario>? GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }

        public async Task<Usuario>? GetByNameAsync(string name, string lastname)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre.Equals(name) && u.Apellido.Equals(lastname));
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }

        public async Task<bool> SaveAsync(Usuario usuario)
        {
            if (usuario.IdUsuario == 0) 
            {
                _context.Usuarios.Add(usuario);
            }
            else
            {
                _context.Usuarios.Update(usuario);
            }
            return await _context.SaveChangesAsync() != 0;
        }
    }
}
