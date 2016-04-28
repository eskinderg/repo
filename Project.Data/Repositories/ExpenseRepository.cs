using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Project.Data.IRepositories;
using Project.Model;

namespace Project.Data.Repositories
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

        public IEnumerable<Expense> GetExpiredExpenses()
        {
            return ApplicationDbContext.Expenses.Include(e => e.Category.SubCategory)
                                                .Where(e => e.Date < DateTime.Now);
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Expense> RemoveExpiredExpenses()
        {
            var expiredExpenses = this.GetExpiredExpenses();
            return base.DeleteRange(expiredExpenses, true);
        }
    }
}
