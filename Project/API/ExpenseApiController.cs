using System.Collections.Generic;
using System.Web.Http;
using Project.Data.UnitOfWork;
using Project.Model;

namespace Project.API
{
    [RoutePrefix("Api")]
    public class ExpenseApiController : ApiController
    {
        private readonly IUnitOfWork _unitofwork;

        public ExpenseApiController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("expenses")]
        public IEnumerable<Expense> GetExpenses()
        {
            return _unitofwork.Expenses.All();
        }

        [HttpGet]
        [Route("expense/{id}")]
        public Expense GetExpense(int id)
        {
            return _unitofwork.Expenses.GetById(id);
        }

        [HttpGet]
        [Route("getallcategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            return _unitofwork.Categories.GetAllCategories();
        }

        [HttpPost]
        [Route("expense/add")]
        public Expense Add(Expense expense)
        {
            return ModelState.IsValid ? _unitofwork.Expenses.Insert(expense,true) : null;
        }
    }
}