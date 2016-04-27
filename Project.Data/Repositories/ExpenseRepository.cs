using System;
using System.Collections.Generic;
using System.Linq;
using Project.Model;
using System.Data.Entity;

namespace Project.Data
{
    public class ExpenseRepository: Repository<Expense>, IExpenseRepository
    {
        
        public ExpenseRepository(ApplicationDbContext context):base(context)
        { }

        public Expense GetById(int id)
        {
            return ApplicationDbContext.Expenses.Find(id);
        }

        public IEnumerable<Expense> All()
        {
            return ApplicationDbContext.Expenses.Include(e => e.Category.SubCategory);
        }

        public IEnumerable<Expense> GetAllUnexpiredExpenses()
        {
            return ApplicationDbContext.Expenses.Include(e => e.Category.SubCategory)
                                                .Where(e => e.Date > DateTime.Now);
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
