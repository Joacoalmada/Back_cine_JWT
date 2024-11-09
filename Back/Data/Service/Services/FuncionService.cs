using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Back.Data.Service.Interfaces;

namespace Back.Data.Service.Services
{
    public class FuncionService : IFuncionService
    {
        IFuncionRepository _repository;

        public FuncionService(IFuncionRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Eliminar(int id)
        {
            return _repository.Delete(id);
        }

        public Task<bool> Guardar(Funcione funcione)
        {
            return _repository.Save(funcione);
        }

        public Task<List<Funcione>> ObtenerFunciones()
        {
            return _repository.GetAll();
        }

        public Task<List<Funcione>> ObtenerFuncionesPorDia(int dia)
        {
            return _repository.GetByDay(dia);
        }

        public Task<Funcione>? ObtenerFuncionesPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
