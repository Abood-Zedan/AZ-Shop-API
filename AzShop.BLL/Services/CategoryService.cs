using AzShop.DAL.DTO.Requests;
using AzShop.DAL.DTO.Responses;
using AzShop.DAL.Models;
using AzShop.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return _categoryRepository.Add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null) return 0;
            return _categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse? GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null) return 0;
            category.Name = request.Name;
            return _categoryRepository.UpDate(category);
        }
        public bool ToggleStatus(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null) return false;
            category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
            _categoryRepository.UpDate(category);
            return true;
        }
    }
}
