using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse? GetCategoryById(int id);
        int UpdateCategory(int id, CategoryRequest request);
        int DeleteCategory(int id);
        bool ToggleStatus(int id);
    }
}
