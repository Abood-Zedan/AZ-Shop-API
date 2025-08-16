using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.DAL.DTO.Requests
{
    public class BrandRequest
    {
        public IFormFile Image { get; set; }
    }
}
