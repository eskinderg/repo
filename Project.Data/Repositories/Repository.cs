using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Project.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {

        protected readonly DbContext Context;


        public Repository(DbContext context)
        {
            Context = context;
        }

        //protected DbSet<T> DbSet { get; set; }


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


        public void Dispose()
        {
            Context.Dispose();
        }

        public IEnumerable<T> Select()
        {
            return Context.Set<T>();
        }

    }

}