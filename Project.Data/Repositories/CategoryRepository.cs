using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Data
{
    public class CategoryRepository : Repository<CategoryRepository>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context):base(context)
        { }
        public IEnumerable<Category> GetAllCategories()
        {
            return ApplicationDbContext.Categories.ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
