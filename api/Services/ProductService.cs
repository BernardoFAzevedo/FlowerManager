using api.Dtos.Product;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using api.Dtos.Common;

namespace api.Services
{
    public class ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IUnitRepository unitRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IUnitRepository _unitRepository = unitRepository;

        private const int DEFAULT_PAGE_SIZE = 10;
        private const int DEFAULT_NPAGES = 1;

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                StockNow = p.StockNow,
                ProductCategoryId = p.ProductCategoryId,
                ProductCategoryName = p.ProductCategory?.Name,
                ProductUnitId = p.ProductUnitId,
                ProductUnitName = p.ProductUnit?.Name,
                Supplier = p.Supplier
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _productRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                StockNow = p.StockNow,
                ProductCategoryId = p.ProductCategoryId,
                ProductCategoryName = p.ProductCategory?.Name,
                ProductUnitId = p.ProductUnitId,
                ProductUnitName = p.ProductUnit?.Name,
                Supplier = p.Supplier
            };
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.ProductCategoryId)
                ?? throw new KeyNotFoundException("Category not found.");

            var unit = await _unitRepository.GetByIdAsync(dto.ProductUnitId)
                ?? throw new KeyNotFoundException("Unit not found.");

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                StockNow = dto.StockNow,
                ProductCategoryId = dto.ProductCategoryId,
                ProductUnitId = dto.ProductUnitId,
                Supplier = dto.Supplier
            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                StockNow = product.StockNow,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = category.Name,
                ProductUnitId = product.ProductUnitId,
                ProductUnitName = unit.Name,
                Supplier = product.Supplier
            };
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            var category = await _categoryRepository.GetByIdAsync(dto.ProductCategoryId)
                ?? throw new KeyNotFoundException("Category not found.");

            var unit = await _unitRepository.GetByIdAsync(dto.ProductUnitId)
                ?? throw new KeyNotFoundException("Unit not found.");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.UnitPrice = dto.UnitPrice;
            product.StockNow = dto.StockNow;
            product.ProductCategoryId = dto.ProductCategoryId;
            product.ProductUnitId = dto.ProductUnitId;
            product.Supplier = dto.Supplier;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                StockNow = product.StockNow,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = category.Name,
                ProductUnitId = product.ProductUnitId,
                ProductUnitName = unit.Name,
                Supplier = product.Supplier
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            product.IsActive = false;
            _productRepository.Update(product);
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<bool> RestoreAsync(int id)
        {
            var product = await _productRepository.GetByIdIncludingInactiveAsync(id);
            if (product == null) return false;
            product.IsActive = true;
            _productRepository.Update(product);
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductDto>> GetPagedAsync(PaginationQuery query)
        {
            var page = query?.Page ?? DEFAULT_NPAGES;
            var pageSize = query?.PageSize ?? DEFAULT_PAGE_SIZE;

            var paged = await _productRepository.GetPagedAsync(page, pageSize);

            return new PagedResult<ProductDto>
            {
                Items = paged.Items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    UnitPrice = p.UnitPrice,
                    StockNow = p.StockNow,
                    ProductCategoryId = p.ProductCategoryId,
                    ProductCategoryName = p.ProductCategory?.Name,
                    ProductUnitId = p.ProductUnitId,
                    ProductUnitName = p.ProductUnit?.Name,
                    Supplier = p.Supplier
                }),
                TotalCount = paged.TotalCount,
                Page = paged.Page,
                PageSize = paged.PageSize
            };
        }
    }
}
