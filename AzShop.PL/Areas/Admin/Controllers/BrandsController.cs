using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzShop.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(_brandService.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = _brandService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] BrandRequest request)
        {
            var id = await _brandService.CreateFile(request);
            return CreatedAtAction(nameof(Get), new { id }, new { message = request });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var update = _brandService.Update(id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var update = _brandService.ToggleStatus(id);
            return update ? Ok(new { message = "status toggled" }) : NotFound(new { message = "category not found" });
        }
        [HttpDelete("")]
        public IActionResult Delete([FromRoute] int id)
        {
            var delete = _brandService.Delete(id);
            return delete > 0 ? Ok() : NotFound();
        }
    }
}
