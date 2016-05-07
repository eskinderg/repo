using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Project.Data.Mapping;
using Project.Model;
using Project.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Project.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("ProjectDB") {
            Database.SetInitializer<ApplicationDbContext>(null);
            Configuration.LazyLoadingEnabled = false; 
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Folder> Folders { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                    type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
