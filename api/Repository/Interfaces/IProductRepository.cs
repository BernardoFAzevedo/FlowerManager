using api.Models;
using api.Dtos.Common;
namespace api.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<Product?> GetByIdIncludingInactiveAsync(int id);
        Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize);
        Task<bool> SaveChangesAsync();
    }
}
