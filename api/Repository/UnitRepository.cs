using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDBContext _context;

        public UnitRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductUnit>> GetAllAsync()
        {
            return await _context.ProductUnits.ToListAsync();
        }

        public async Task<ProductUnit?> GetByIdAsync(int id)
        {
            return await _context.ProductUnits.FindAsync(id);
        }

        public async Task AddAsync(ProductUnit unit)
        {
            await _context.ProductUnits.AddAsync(unit);
        }

        public void Update(ProductUnit unit)
        {
            _context.ProductUnits.Update(unit);
        }

        public void Delete(ProductUnit unit)
        {
            _context.ProductUnits.Remove(unit);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
