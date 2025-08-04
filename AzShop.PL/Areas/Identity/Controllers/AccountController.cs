using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzShop.PL.Areas.Identity.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPatch("Register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            return Ok(result);
        }
        [HttpPatch("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
