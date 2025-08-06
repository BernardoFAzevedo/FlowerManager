using api.Models;

namespace api.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(int id);
        Task AddAsync(ProductCategory category);
        void Update(ProductCategory category);
        void Delete(ProductCategory category);
        Task<bool> SaveChangesAsync();
    }
}
