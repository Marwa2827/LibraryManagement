using LibraryManagement.DTOs.Categories;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound(new { message = "Category not found." });

            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            var result = await _categoryService.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(new { message = result.Error });

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Category!.Id },
                result.Category);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(
            int id,
            CategoryDto dto)
        {
            var result =
                await _categoryService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                if (result.Error == "Category not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Category updated successfully."
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                if (result.Error == "Category not found.")
                    return NotFound(new { message = result.Error });

                return BadRequest(new { message = result.Error });
            }

            return Ok(new
            {
                message = "Category deleted successfully."
            });
        }
    }
}
