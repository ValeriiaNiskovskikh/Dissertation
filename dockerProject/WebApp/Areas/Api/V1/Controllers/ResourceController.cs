using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class ResourceController: BaseApiV1Controller
    {
        [HttpGet("[action]")]
        public object GetAll()
        {
            return "all";
        }

        [HttpGet("[action]/{sourceId}")]
        public object GetAll(string sourceId)
        {
            return "all by id";
        }
        
        
    }
}