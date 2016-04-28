using System.Collections.Generic;
using Project.Model;

namespace Project.Data.ExpenseManager
{
    public interface IExpenseManager
    {
        void RemoveExpiredExpenses();
        IEnumerable<Expense> GetExpiredExpenses();
        bool DeleteExpense(int expenseId);
        
    }
}
