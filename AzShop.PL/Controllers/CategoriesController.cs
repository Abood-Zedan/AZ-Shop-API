using AzShop.BLL.Services;
using AzShop.DAL.DTO.Requests;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzShop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }
        [HttpPost("")]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = _categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(Get), new { id });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var update = _categoryService.UpdateCategory(id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var update = _categoryService.ToggleStatus(id);
            return update ? Ok(new {message ="status toggled"}) : NotFound(new {message = "category not found"});
        }
        [HttpDelete("")]
        public IActionResult Delete([FromRoute] int id)
        {
            var delete = _categoryService.DeleteCategory(id);
            return delete > 0 ? Ok() : NotFound();
        }
    }
}
