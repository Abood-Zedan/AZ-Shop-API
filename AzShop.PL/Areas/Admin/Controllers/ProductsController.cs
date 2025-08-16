using AzShop.BLL.Services.Classes;
using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzShop.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            var result = await _productService.CreateFile(request);
            return Ok(result);
        }
        
    }
}
