using AzShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.DAL.Repository
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        Category? GetById(int id);
        int Remove(Category category);
        int UpDate(Category category);
    }
}
