using Back.Data.Models;

namespace Back.Data.Service.Interfaces
{
    public interface ITransaccionService
    {
        Task<List<Transaccione>> ObtenerTransacciones();
        Task<Transaccione>? ObtenerTransaccionPorId(int id);
        Task<List<Transaccione>> ObtenerTransaccionesPorFecha(DateTime fecha);
        Task<bool> Guardar(Transaccione transaccion);
        Task<bool> Eliminar(int id);
    }
}
