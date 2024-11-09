using Back.Data.Models;

namespace Back.Data.Service.Interfaces
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerPeliculas();
        Task<Pelicula>? ObtenerPeliculaPorId(int id);
        Task<bool> GuardarPelicula(Pelicula p);
        Task<bool> EliminarPelicula(int id);
        Task<Pelicula>? ObtenerPeliculaPorTitulo(string titulo);
    }
}
