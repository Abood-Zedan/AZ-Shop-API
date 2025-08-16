using AzShop.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.DAL.DTO.Requests
{
    public class ProductRequest
    {
        public string name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quntity { get; set; }
        public IFormFile MainImage { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
