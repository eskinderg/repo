using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Project.Data.UnitOfWork;
using Project.Model;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.API
{
    [RoutePrefix("Api")]
    public class ContentApiController : ApiController
    {
        private readonly IUnitOfWork _unitofwork;

        public ContentApiController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("contents")]
        public IEnumerable<Content> GetAllContents()
        {
            //IEnumerable<ContentViewModel> CVM = Mapper.Map<IEnumerable<ContentViewModel>>(_unitofwork.Contents.GetAllContents());
            
            //List<ContentViewModel> list = _unitofwork.Contents.GetAllContents().ToList().Select(Mapper.Map<ContentViewModel>).ToList();

            return _unitofwork.Contents.GetAllContents();
        }

        [HttpGet]
        [Route("content/{id}")]
        public Content GetContent(int id)
        {
            return _unitofwork.Contents.GetContent(id);
        }

        [HttpGet]
        [Route("getallcategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            return _unitofwork.Categories.GetAllCategories();
        }

        [HttpPost]
        [Route("content/add")]
        public Content Add(Content content)
        {
            return ModelState.IsValid ? _unitofwork.Contents.AddContent(content) : null;
        }
    }
}