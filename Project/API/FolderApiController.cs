using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Data.UnitOfWork;
using Project.Model.Models;

namespace Project.API
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
        public IEnumerable<Folder> Folders()
        {
            return _unitofwork.Folders.GetAllFolders();
        }


    }
}
