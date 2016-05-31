﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model.Models;

namespace Project.Data.Repositories
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext context) : base(context)
        {  }

        public IEnumerable<Content> GetAllContents()
        {
            return Select().Any() ? Select().Include(c=>c.Folder) : null;
        }

        public Content GetContent(int id)
        {
            return Select().Where(c => c.Id == id).
                                        Include(c => c.Folder).
                                        FirstOrDefault();
        }

        public Content AddContent(Content content)
        {
            return Insert(content, true);
        }
    }
}
