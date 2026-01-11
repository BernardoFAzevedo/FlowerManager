using api.Dtos.Product;
using api.Dtos.Common;

namespace api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> RestoreAsync(int id);
        Task<PagedResult<ProductDto>> GetPagedAsync(PaginationQuery query);
    }
}
