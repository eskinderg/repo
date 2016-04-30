using System.Collections.Generic;
using Project.Model;

namespace Project.Data.ExpenseManager
{
    public interface IExpenseManager
    {
        void RemoveExpiredExpenses();
        IEnumerable<Expense> GetExpiredExpenses();
        IEnumerable<Expense> GetUnExpiredExpenses(); 
        bool DeleteExpense(int expenseId);
        
    }
}
