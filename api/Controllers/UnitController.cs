using api.Dtos.Unit;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class UnitController(IUnitService service) : ControllerBase
    {
        private readonly IUnitService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUnitDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var unit = await _service.CreateAsync(dto);
            return Ok(unit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUnitDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
