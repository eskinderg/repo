using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IExpenseRepository Expenses { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Expenses = new ExpenseRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
