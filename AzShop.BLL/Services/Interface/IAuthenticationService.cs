using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
       Task<UserResponse> LoginAsync(LoginRequest loginRequest);
       Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
       Task<string> ConfirmEmail(string token , string userId );
       Task<bool> ForgotPasswordAsync(ForgotPassword request);
       Task<bool> ResetPasswordAsync(ResetPasswordRequest request);


    }
}
