using System.Web.Mvc;
using System.Web.UI;
using Project.Data.UnitOfWork;

namespace Project.Controllers
{
    public class ContentController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public ContentController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {

#region Comments 
            //var x = _unitofwork.Contents.GetContent(5).Folder.Name;


            //XmlDocument xDoc = new XmlDocument();
            //xDoc.LoadXml(x);

            //var rootFolder = _unitofwork.Folders.GetFolder(1);
            //ViewBag.HH = "";
            /*
            foreach (var folder in rootFolder.Children)
            {
                ViewBag.HH += folder.Name +" | ";
            }*/

            /*
           Content c = new Content
            {
                Folder = rootFolder,
                HTML = "<p>Quick brown</p>",
                Summary = "content summary",
                Title = "content title"
            };*/

            //_unitofwork.Contents.AddContent(c);

            //var rootFolders = _unitofwork.Folders.RootFolders;


            // _unitofwork.Contents.GetAllContents().FirstOrDefault(co => co.Title == "New Content Title").Folder.Name;

            //ViewBag.HH = rootFolders.FirstOrDefault().Name;

            //ViewBag.HH =  Mapper.Map<ContentViewModel> (_unitofwork.Contents.GetContent(6)).Folder.Parent.Name;

            //var list = _unitofwork.Contents.GetAllContents().ToList();//.Select(Mapper.Map<ContentViewModel>).ToList();
#endregion

            var contentList = _unitofwork.Contents.GetAllContents();
            return View(contentList);
        }

        public ActionResult DeleteExpired()
        {
            //_expenseManager.RemoveExpiredExpenses();
            return Content("Reponse Completed Sucsussfully");
        }
    }
}