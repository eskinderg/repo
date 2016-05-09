using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Project.Data.UnitOfWork;
using Project.Model;
using Project.Model.Models;
using Project.Model.ViewModels;
using Project.Attribute;
using System.Web.Http.OData;

namespace Project.Api
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
        [CacheClient(Duration =20)]
        [EnableQuery]
        //[ResponseType(typeof(IEnumerable<ContentViewModel>))]
        public IEnumerable<ContentViewModel> GetAllContents()
        {
            IEnumerable<ContentViewModel> CVM = Mapper.Map<IEnumerable<ContentViewModel>>(_unitofwork.Contents.GetAllContents());

            //List<ContentViewModel> list = _unitofwork.Contents.GetAllContents().ToList().Select(Mapper.Map<ContentViewModel>).ToList();

            return CVM; //_unitofwork.Contents.GetAllContents();
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