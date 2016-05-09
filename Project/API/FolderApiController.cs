using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Project.Data.UnitOfWork;
using Project.Model.ViewModels;

namespace Project.Api
{
    [RoutePrefix("Api")]
    public class FolderApiController : ApiController
    {
        private readonly IUnitOfWork _unitofwork;

        public FolderApiController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("folders")]
        public IEnumerable<FolderViewModel> Folders()
        {
            IEnumerable<FolderViewModel> CVM = Mapper.Map<IEnumerable<FolderViewModel>>(_unitofwork.Folders.GetAllFolders());

            return CVM; // _unitofwork.Folders.GetAllFolders();
        }


    }
}
