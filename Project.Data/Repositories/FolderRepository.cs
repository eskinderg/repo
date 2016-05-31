using System.Collections.Generic;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model.Models;

namespace Project.Data.Repositories
{
    public class FolderRepository : Repository<Folder> , IFolderRepository
    {
        public FolderRepository(ApplicationDbContext context) : base(context)
        {}

        public IEnumerable<Folder> GetAllFolders()
        {
            return Select();
        }

        public Folder GetFolder(string name)
        {
            return Select().FirstOrDefault(f => f.Name==name);
        }

        public Folder GetFolder(int id)
        {
            return Select().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Folder> RootFolders
        {
            get { return Select().Where(f => f.Name == null); }
        }
    }
}
