using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class SourceController : BaseApiV1Controller
    {
        [HttpGet("[action]")]
        public object GetAll()
        {
            return "all sources";
        }

        [HttpPost("[action]")]
        public object Create()
        {
            return "ok";
        }

        [HttpPost("[action]")]
        public object Delete()
        {
            return "ok";
        }

        [HttpPost("[action]")]
        public object AddResource()
        {
            return "oke";
        }
        
    }
}