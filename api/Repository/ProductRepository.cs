using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Common;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductUnit)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductUnit)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Product?> GetByIdIncludingInactiveAsync(int id)
        {
            return await _context.Products
                .IgnoreQueryFilters()
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductUnit)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductUnit)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
