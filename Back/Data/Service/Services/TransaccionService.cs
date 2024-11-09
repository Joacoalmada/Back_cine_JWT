using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Back.Data.Service.Interfaces;

namespace Back.Data.Service.Services
{
    public class TransaccionService : ITransaccionService
    {
        ITransaccionRepository _repository;

        public TransaccionService(ITransaccionRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Eliminar(int id)
        {
            return  _repository.Delete(id);
        }

        public Task<bool> Guardar(Transaccione transaccion)
        {
            return _repository.Save(transaccion);
        }

        public Task<List<Transaccione>> ObtenerTransacciones()
        {
            return _repository.GetAll();
        }

        public Task<List<Transaccione>> ObtenerTransaccionesPorFecha(DateTime fecha)
        {
            return _repository.GetByDate(fecha);
        }

        public Task<Transaccione>? ObtenerTransaccionPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
