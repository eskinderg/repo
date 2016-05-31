using System.Web.Mvc;
using Project.Data.ExpenseManager;
using Project.Data.IRepositories;
using Project.Data.UnitOfWork;

namespace Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        private readonly IExpenseManager _expenseManager;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.Contents.GetAllContents());
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