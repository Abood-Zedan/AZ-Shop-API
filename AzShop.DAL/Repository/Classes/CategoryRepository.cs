using AzShop.DAL.Data;
using AzShop.DAL.Models;
using AzShop.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzShop.DAL.Repository.Classes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
