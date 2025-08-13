using api.Data;
using api.Repository.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task AddAsync(ProductCategory category)
        {
            await _context.ProductCategories.AddAsync(category);
        }

        public void Update(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
        }

        public void Delete(ProductCategory category)
        {
            _context.ProductCategories.Remove(category);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
