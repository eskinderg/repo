using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Mapping.Expenses
{
    public class ExpensesMap: BNAEntityTypeConfiguration<Expense>
    {
        public ExpensesMap()
        {
            //Key
            //this.HasKey(e => e.Id);


            //Properties
            //this.Property(e => e.SubCategory.Id).HasColumnName("SubCategory_Id");
                /*this.HasOptional(e => e.Category)// Expense has an optional category
                .WithMany() // Category may be owned by many Expenses
                .HasForeignKey*/

            //Relationship
            //this.HasOptional(e=>e.Category).h

            //Table
                this.ToTable("Expenses");
        }
    }
}
