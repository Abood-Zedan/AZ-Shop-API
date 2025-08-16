using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Interface
{
    public interface IFileServices
    {
        public Task<string> UploadAsync(IFormFile file);
    }
}
