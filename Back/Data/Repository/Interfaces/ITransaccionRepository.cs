using Back.Data.Models;

namespace Back.Data.Repository.Interfaces
{
    public interface ITransaccionRepository
    {
        Task<List<Transaccione>> GetAll();
        Task<Transaccione>? GetById(int id);
        Task<List<Transaccione>>? GetByDate(DateTime? date);
        Task<bool> Save(Transaccione transaccion);
        Task<bool> Delete(int id);

    }
}
