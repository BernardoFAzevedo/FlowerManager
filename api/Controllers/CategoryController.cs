
using api.Dtos.Category;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        private readonly ICategoryService _service = service;

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
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var category = await _service.CreateAsync(dto);
                return Ok(dto);
            }
            catch (InvalidOperationException)
            {
                return Conflict(new { message = "Maximum number of categories reached!"});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto dto)
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
