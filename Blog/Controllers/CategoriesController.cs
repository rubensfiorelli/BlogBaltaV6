using Blog.Application.InputModels;
using Blog.Application.Repositories;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.Controllers
{
    [Route("v6")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            if (categories is null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetId([FromRoute] Guid id)
        {
            var category = await _categoryService.GetId(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> Post([FromBody] CategoryInputModel model)
        {
            await _categoryService.Add(model);

            return Created($"categories/{model.Slug}", model);

        }

        [HttpPut("categories/{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCategoryViewModel model)
        {

            var category = await _categoryService.Put(id, model);

            await _categoryService.Put(id, model);

            if (category is not null)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Erro ao atualizar a categoria");
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
