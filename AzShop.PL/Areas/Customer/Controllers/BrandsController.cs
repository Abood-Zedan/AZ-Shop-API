using AzShop.BLL.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzShop.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(_brandService.GetAll(true));
        
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = _brandService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }
    }
}
