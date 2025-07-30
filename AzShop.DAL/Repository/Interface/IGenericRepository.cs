using AzShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.DAL.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        int Add(T entity);
        IEnumerable<T> GetAll(bool withTracking = false);
        T? GetById(int id);
        int Remove(T entity);
        int UpDate(T entity);
    }
}
