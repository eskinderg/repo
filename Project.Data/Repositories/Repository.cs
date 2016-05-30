using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model;

namespace Project.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        
        protected readonly DbContext Context; 
        
        protected Repository(DbContext context)
        {
            Context = context;
        }

        public T Insert(T item, bool saveNow)
        {
            try
            {
                Context.Entry(item).State = EntityState.Added;

                if (saveNow)
                    Context.SaveChanges();
                return item;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                                    .SelectMany(x => x.ValidationErrors)
                                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
        }

        public T Update(T item, bool saveNow)
        {
            Context.Entry(item).State = EntityState.Modified;

            if (saveNow)
                Context.SaveChanges();
            return item;
        }


        public T Delete(T item, bool saveNow)
        {
            Context.Entry(item).State = EntityState.Deleted;

            if (saveNow)
                Context.SaveChanges();
            return item;
        }


        public int Save()
        {
            return Context.SaveChanges();
        }

        public IQueryable<T> Select()
        {
            return Context.Set<T>();
        }


        public IEnumerable<T> DeleteRange(IEnumerable<T> items, bool saveNow)
        {
            Context.Set<T>().RemoveRange(items);

            if (saveNow)
                Context.SaveChanges();
            return items;
        }


        public IEnumerable<T> InsertRange(IEnumerable<T> items, bool saveNow)
        {
            Context.Set<T>().AddRange(items);

            if (saveNow)
                Context.SaveChanges();
            return items;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

}