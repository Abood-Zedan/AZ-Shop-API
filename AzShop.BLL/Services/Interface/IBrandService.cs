using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using AzShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Interface
{
    public interface IBrandService : IGenericService<BrandRequest,BrandResponse,Brand>
    {
    }
}
