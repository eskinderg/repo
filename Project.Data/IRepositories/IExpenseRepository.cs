using System.Collections.Generic;
using Project.Model;

namespace Project.Data
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Expense GetById(int id);

        IEnumerable<Expense> All();

        IEnumerable<Expense> GetAllUnexpiredExpenses();

    }
}
