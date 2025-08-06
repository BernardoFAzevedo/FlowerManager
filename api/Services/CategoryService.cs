using api.Dtos.Category;
using api.Repository.Interfaces;
using api.Models;
using api.Services.Interfaces;

namespace api.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private const int MaxCategories = 2;

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var existingCount = (await _categoryRepository.GetAllAsync()).Count();

        if (existingCount >= MaxCategories)
            throw new InvalidOperationException();

        var category = new ProductCategory { Name = dto.Name };
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }

        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;

            category.Name = dto.Name;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            return new CategoryDto { Id = category.Id, Name = category.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            _categoryRepository.Delete(category);
            return await _categoryRepository.SaveChangesAsync();
        }
    }
}
