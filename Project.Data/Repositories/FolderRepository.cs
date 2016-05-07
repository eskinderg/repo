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
            return ApplicationDbContext.Folders;
        }

        public Folder GetFolder(string name)
        {
            return ApplicationDbContext.Folders.FirstOrDefault(f => f.Name==name);
        }

        public Folder GetFolder(int id)
        {
            return ApplicationDbContext.Folders.FirstOrDefault(f => f.Id == id);
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }


        public IEnumerable<Folder> RootFolders
        {
            get { return ApplicationDbContext.Folders.Where(f => f.Name == null); }
        }
    }
}
