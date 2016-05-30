using System.Collections.Generic;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model;

namespace Project.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context):base(context)
        { }
        public IEnumerable<Category> GetAllCategories()
        {
            return Select().Any() ? Select() : null;
        }
    }
}
