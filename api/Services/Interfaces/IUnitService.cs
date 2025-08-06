using api.Dtos.Unit;

namespace api.Services.Interfaces
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetAllAsync();
        Task<UnitDto?> GetByIdAsync(int id);
        Task<UnitDto> CreateAsync(CreateUnitDto dto);
        Task<UnitDto?> UpdateAsync(int id, UpdateUnitDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
