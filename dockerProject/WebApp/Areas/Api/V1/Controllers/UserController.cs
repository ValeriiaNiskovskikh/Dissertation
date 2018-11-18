using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class UserController : BaseApiV1Controller
    {
        [HttpPost("[action]")]
        public string Login()
        {
            return "login success";
        }

        [HttpGet("[action]/{id}")]
        public string GetPermissions(string id)
        {
            return "permissions";
        }

        [HttpPost("[action]")]
        public string Logout()
        {
            return "logout";
        }
    }
}