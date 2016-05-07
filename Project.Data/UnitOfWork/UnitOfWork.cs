using System;
using Project.Data.IRepositories;
using Project.Data.Repositories;

namespace Project.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IExpenseRepository Expenses { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IContentRepository Contents { get; private set; }
        public IFolderRepository Folders { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Expenses = new ExpenseRepository(_context);
            Categories = new CategoryRepository(_context);
            Contents = new ContentRepository(_context);
            Folders = new FolderRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }




    }
}
