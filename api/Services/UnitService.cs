using api.Dtos.Unit;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;

namespace api.Services
{
    public class UnitService(IUnitRepository repository) : IUnitService
    {
        private const int MaxUnits = 20; 
        private readonly IUnitRepository _unitRepository = repository;

        public async Task<IEnumerable<UnitDto>> GetAllAsync()
        {
            var units = await _unitRepository.GetAllAsync();
            return units.Select(u => new UnitDto
            {
                Id = u.Id,
                Name = u.Name
            });
        }

        public async Task<UnitDto?> GetByIdAsync(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit == null) return null;

            return new UnitDto { Id = unit.Id, Name = unit.Name };
        }

        public async Task<UnitDto> CreateAsync(CreateUnitDto dto)
        {
            var existingCount = (await _unitRepository.GetAllAsync()).Count();

            if (existingCount >= MaxUnits)
                throw new InvalidOperationException();

            var unit = new ProductUnit { Name = dto.Name };
            await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAsync();

            return new UnitDto { Id = unit.Id, Name = unit.Name };
        }

        public async Task<UnitDto?> UpdateAsync(int id, UpdateUnitDto dto)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit == null) return null;

            unit.Name = dto.Name;
            _unitRepository.Update(unit);
            await _unitRepository.SaveChangesAsync();

            return new UnitDto { Id = unit.Id, Name = unit.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit == null) return false;

            _unitRepository.Delete(unit);
            return await _unitRepository.SaveChangesAsync();
        }
    }
}
