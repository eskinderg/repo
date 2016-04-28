using System.Data.Entity;
using Project.Model;

namespace Project.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("ProjectDB") {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany<Expense>(c=>c.ex
        }
         */

    }
}
