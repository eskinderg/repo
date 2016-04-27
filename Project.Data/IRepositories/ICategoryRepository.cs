using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
