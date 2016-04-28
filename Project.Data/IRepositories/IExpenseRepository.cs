using System.Collections.Generic;
using Project.Model;

namespace Project.Data.IRepositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Expense GetById(int id);

        IEnumerable<Expense> All();

        IEnumerable<Expense> GetAllUnexpiredExpenses();

        IEnumerable<Expense> GetExpiredExpenses();

        IEnumerable<Expense> RemoveExpiredExpenses();

    }
}
