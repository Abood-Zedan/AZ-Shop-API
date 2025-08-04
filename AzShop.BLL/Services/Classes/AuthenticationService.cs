using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using AzShop.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if(user is null)
            {
                throw new Exception("Invalid email or password");
            }

            var isPassValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!isPassValid)
            {
                throw new Exception("Invalid email or password");
            }
            
            return new UserResponse()
            {
                Token = await CreateTokenAsync(user)
            };
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                UserName = registerRequest.UserName,
                PhoneNumber = registerRequest.PhoneNumber,
                Email = registerRequest.Email,
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                return new UserResponse()
                {
                    Token = registerRequest.Email
                };
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach(var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtOptions")["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
