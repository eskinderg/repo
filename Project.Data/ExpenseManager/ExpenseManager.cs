using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data.IRepositories;
using Project.Model;

namespace Project.Data.ExpenseManager
{
    public class ExpenseManager : IExpenseManager
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseManager(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public void RemoveExpiredExpenses()
        {
            _expenseRepository.RemoveExpiredExpenses();
        }

        public IEnumerable<Expense> GetExpiredExpenses()
        {
            return _expenseRepository.GetExpiredExpenses();
        }

        public bool DeleteExpense(int expenseId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Expense> GetUnExpiredExpenses()
        {
            return _expenseRepository.GetAllUnexpiredExpenses();
        }
    }
}
