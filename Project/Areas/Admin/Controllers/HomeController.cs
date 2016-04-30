using System.Web.Mvc;
using Project.Data.ExpenseManager;
using Project.Data.IRepositories;

namespace Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        private readonly IExpenseManager _expenseManager;
        private readonly IExpenseRepository _expenseRepository;


        public HomeController(IExpenseManager expenseManager, IExpenseRepository expenseRepository)
        {
            _expenseManager = expenseManager;
            _expenseRepository = expenseRepository;
        }

        public ActionResult Index()
        {
            return View(_expenseManager.GetExpiredExpenses());
        }


        public ActionResult Expired()
        {
            return View(_expenseManager.GetExpiredExpenses());
        }

        public ActionResult UnExpired()
        {
            return View(_expenseManager.GetUnExpiredExpenses());
        }

        public ActionResult Details(int id)
        {
            return Content(_expenseRepository.GetById(id).Description);
        }
	}
}