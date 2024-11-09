using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Data.Repository.Repositories
{
    public class PeliculaRepository : IPeliculasRepository
    {
        CineDBContext _context;

        public PeliculaRepository(CineDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteById(int id)
        {
            var pelicula = GetById(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(await pelicula);
                return await _context.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<List<Pelicula>> GetAll()
        {
            return await _context.Peliculas.ToListAsync();
        }

        public async Task<Pelicula>? GetById(int id)
        {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.CodPelicula == id);
            if (pelicula != null)
            {
                return pelicula;
            }
            return null;
        }

        public async Task<Pelicula>? GetByTitle(string title)
        {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.Titulo == title);
            if (pelicula != null)
            {
                return pelicula;
            }
            return null;
        }

        public async Task<bool> Save(Pelicula p)
        {
            if (p.CodPelicula == 0)
            {
                _context.Peliculas.Add(p);
            }
            else
            {
                _context.Peliculas.Update(p);
            }
            return await _context.SaveChangesAsync() != 0;
        }
    }
}
