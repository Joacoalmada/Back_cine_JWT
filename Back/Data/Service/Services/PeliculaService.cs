using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Back.Data.Service.Interfaces;

namespace Back.Data.Service.Services
{
    public class PeliculaService : IPeliculaService
    {
        IPeliculasRepository _repository;

        public PeliculaService(IPeliculasRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> EliminarPelicula(int id)
        {
            return _repository.DeleteById(id);
        }

        public Task<bool> GuardarPelicula(Pelicula p)
        {
            return _repository.Save(p);
        }

        public Task<Pelicula>? ObtenerPeliculaPorId(int id)
        {
            return _repository.GetById(id);
        }

        public Task<Pelicula>? ObtenerPeliculaPorTitulo(string titulo)
        {
            return _repository.GetByTitle(titulo);
        }

        public Task<List<Pelicula>> ObtenerPeliculas()
        {
            return _repository.GetAll();
        }
    }
}
