using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Data.IRepositories
{
    public interface IContentRepository
    {
        IEnumerable<Content> GetAllContents();

        Content GetContent(int id);

        Content AddContent(Content content);
    }
}
