using System.Web.Mvc;
using Project.Data.ExpenseManager;
using Project.Data.UnitOfWork;

namespace Project.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IExpenseManager _expenseManager;

        public ExpenseController(IUnitOfWork unitofwork, IExpenseManager expenseManager)
        {
            _unitofwork = unitofwork;
            _expenseManager = expenseManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteExpired()
        {
            _expenseManager.RemoveExpiredExpenses();
            return Content("Reponse Completed Sucsussfully");
        }
    }
}