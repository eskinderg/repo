using System;
using Project.Data.IRepositories;

namespace Project.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IExpenseRepository Expenses { get; }
        ICategoryRepository Categories { get; }
    }
}
