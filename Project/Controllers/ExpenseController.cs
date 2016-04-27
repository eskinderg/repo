using System.Web.Mvc;
using Project.Data;

namespace Project.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public ExpenseController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}