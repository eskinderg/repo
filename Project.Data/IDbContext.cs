using System.Collections.Generic;
using System.Data.Entity;
using Project.Model;

namespace Project.Data
{
    public interface IDbContext
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

    }
}
