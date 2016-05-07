using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Project.Data.ExpenseManager;
using Project.Data.UnitOfWork;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.Controllers
{
    public class ContentController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public ContentController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public ActionResult Index()
        {
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


            return View();

            //return View();
        }

        public ActionResult DeleteExpired()
        {
            //_expenseManager.RemoveExpiredExpenses();
            return Content("Reponse Completed Sucsussfully");
        }
    }
}