using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }
        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
             
    }
}
