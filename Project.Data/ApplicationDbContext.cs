using System.Data.Entity;
using Project.Model;
using System.Reflection;
using System.Linq;
using System;
using Project.Data.Mapping;
using System.Threading;

namespace Project.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("ProjectDB") {
           //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<SubCategory> SubCategories { get; set; }
        
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof(BNAEntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.Entity is BaseEntity && 
                    (x.State == System.Data.Entity.EntityState.Added || 
                    x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                BaseEntity entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.Now;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    //entity.UpdatedBy = identityName;
                    //entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }


    }
}
