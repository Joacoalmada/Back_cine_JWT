using Back.Data.Models;

namespace Back.Data.Repository.Interfaces
{
    public interface IPeliculasRepository
    {
        Task<List<Pelicula>> GetAll();
        Task<Pelicula>? GetById(int id);
        Task<bool> Save(Pelicula p);
        Task<bool> DeleteById(int id);
        Task<Pelicula>? GetByTitle(string title);
    }
}
