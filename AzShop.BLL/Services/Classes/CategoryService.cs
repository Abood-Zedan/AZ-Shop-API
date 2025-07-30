using AzShop.BLL.Services.Interface;
using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using AzShop.DAL.Models;
using AzShop.DAL.Repository.Interface;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest,CategoryResponse,Category> , ICategoryService
    {

        public CategoryService(ICategoryRepository repository) :base(repository)
        {
        }

    }
}
