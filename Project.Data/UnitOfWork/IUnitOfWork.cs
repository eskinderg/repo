using System;

namespace Project.Data
{
    public interface IUnitOfWork: IDisposable
    {
        IExpenseRepository Expenses { get; }
        ICategoryRepository Categories { get; }
    }
}
