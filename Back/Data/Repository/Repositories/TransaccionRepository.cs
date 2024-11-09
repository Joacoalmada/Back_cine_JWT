using Back.Data.Models;
using Back.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Data.Repository.Repositories
{
    public class TransaccionRepository : ITransaccionRepository
    {
        CineDBContext _context;

        public TransaccionRepository(CineDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var transaccion = GetById(id);
            if (transaccion != null)
            {
                _context.Transacciones.Remove(await transaccion);
                return await _context.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<List<Transaccione>> GetAll()
        {
            return await _context.Transacciones.ToListAsync();
        }

        public async Task<List<Transaccione>>? GetByDate(DateTime? date)
        {
            return await _context.Transacciones.Where(t => t.FechaCompra == date).ToListAsync();
            
        }

        public async Task<Transaccione>? GetById(int id)
        {
            var transaccion = await _context.Transacciones.FirstOrDefaultAsync(t => t.CodTransaccion == id);
            if(transaccion != null)
            {
                return transaccion;
            }
            return null;
        }

        public async Task<bool> Save(Transaccione transaccion)
        {
            if (transaccion.CodTransaccion == 0)
            {
                _context.Transacciones.Add(transaccion);
            }
            else
            {
                _context.Transacciones.Update(transaccion);
            }
            return await _context.SaveChangesAsync() != 0;
        }
    }
}
