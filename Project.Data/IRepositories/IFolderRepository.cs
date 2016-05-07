using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Models;

namespace Project.Data.IRepositories
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> GetAllFolders();

        Folder GetFolder(string name);

        Folder GetFolder(int id);

        IEnumerable<Folder> RootFolders { get; } 

    }
}
