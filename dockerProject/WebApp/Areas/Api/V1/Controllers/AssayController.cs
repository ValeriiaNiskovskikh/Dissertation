using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class AssayController : BaseApiV1Controller
    {
       public static List<AssaySourceModel> AssaySourceModels = new List<AssaySourceModel>();

        [HttpGet("[action]/{sourceId}")]
        public AssaySourceModel[] GetBySource(string sourceId)
        {
            return AssaySourceModels.Where(x => x.Source.Id == sourceId).ToArray();
        }
        [HttpGet("[action]")]
        public AssaySourceModel[] GetAll()
        {
            return AssaySourceModels.ToArray();
        }
        
        [HttpPost("[action]")]
        public AssaySourceModel SetForSource(AssaySourceModel model)
        {
            return new AssaySourceModel();
        }
    }
}