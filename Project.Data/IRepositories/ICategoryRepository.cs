using System.Collections.Generic;
using Project.Model;

namespace Project.Data.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
