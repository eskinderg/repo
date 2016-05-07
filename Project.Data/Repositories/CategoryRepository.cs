using System.Collections.Generic;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model;

namespace Project.Data.Repositories
{
    public class CategoryRepository : Repository<CategoryRepository>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context):base(context)
        { }
        public IEnumerable<Category> GetAllCategories()
        {
            return ApplicationDbContext.Categories.Any() ? ApplicationDbContext.Categories : null;
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
