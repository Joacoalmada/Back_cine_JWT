using Back.Data.Models;

namespace Back.Data.Repository.Interfaces
{
    public interface IFuncionRepository
    {
        Task<List<Funcione>> GetAll();
        Task<Funcione>? GetById(int id);
        Task<List<Funcione>>? GetByDay(int day);
        Task<bool> Save(Funcione funcione);
        Task<bool> Delete(int id);
    }
}
