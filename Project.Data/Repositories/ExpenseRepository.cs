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
            return GetById(id);
        }

        public IEnumerable<Expense> All()
        {
            return Select().Include(e => e.Category.SubCategory);
        }

        public IEnumerable<Expense> GetAllUnexpiredExpenses()
        {
            return Select().Include(e => e.Category.SubCategory)
                                                .Where(e => e.Date > DateTime.Now);
        }

        public IEnumerable<Expense> GetExpiredExpenses()
        {
            return Select().Include(e => e.Category.SubCategory)
                                                .Where(e => e.Date < DateTime.Now);
        }

        public IEnumerable<Expense> RemoveExpiredExpenses()
        {
            var expiredExpenses = GetExpiredExpenses();
            return DeleteRange(expiredExpenses, true);
        }
    }
}
