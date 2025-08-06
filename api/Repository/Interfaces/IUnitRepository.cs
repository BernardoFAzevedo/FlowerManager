using api.Models;

namespace api.Repository.Interfaces
{
    public interface IUnitRepository
    {
        Task<IEnumerable<ProductUnit>> GetAllAsync();
        Task<ProductUnit?> GetByIdAsync(int id);
        Task AddAsync(ProductUnit unit);
        void Update(ProductUnit unit);
        void Delete(ProductUnit unit);
        Task<bool> SaveChangesAsync();
    }
}
