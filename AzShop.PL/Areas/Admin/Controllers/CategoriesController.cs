using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzShop.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
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
            return Ok(_categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }
        [HttpPost("")]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = _categoryService.Create(request);
            return CreatedAtAction(nameof(Get), new { id }, new { message = request });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var update = _categoryService.Update(id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var update = _categoryService.ToggleStatus(id);
            return update ? Ok(new { message = "status toggled" }) : NotFound(new { message = "category not found" });
        }
        [HttpDelete("")]
        public IActionResult Delete([FromRoute] int id)
        {
            var delete = _categoryService.Delete(id);
            return delete > 0 ? Ok() : NotFound();
        }
    }
}
