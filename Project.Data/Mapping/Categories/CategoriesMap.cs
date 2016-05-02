using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Mapping.Categories
{
    public class CategoriesMap: BNAEntityTypeConfiguration<Category>
    {
        public CategoriesMap()
        {
            //Key
                //this.HasKey(c => c.Id);

            //Properties
            

            //Table
                this.ToTable("Categories");

            //Relationships
            //this.HasRequired(c => c.)
            /*
            this.HasOptional(c => c.SubCategory)
                .WithMany()
                .HasForeignKey(c => c.);
                */
        }
    }
}
