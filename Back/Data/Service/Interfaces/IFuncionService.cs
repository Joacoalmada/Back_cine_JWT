using Back.Data.Models;

namespace Back.Data.Service.Interfaces
{
    public interface IFuncionService
    {
        Task<List<Funcione>> ObtenerFunciones();
        Task<Funcione>? ObtenerFuncionesPorId(int id);
        Task<List<Funcione>> ObtenerFuncionesPorDia(int dia);
        Task<bool> Guardar(Funcione funcione);
        Task<bool> Eliminar(int id);
    }
}
