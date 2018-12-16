using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class SourceController : BaseApiV1Controller
    {
        private static int _id;
        private static string IdS => $"s{_id++}";

        public static List<SourceModel> SourceModels = new List<SourceModel>()
        {
            new SourceModel()
            {
                Id = IdS,
                Name = $"Источник {_id}",
                Resources = ResourceController.Resources.ToArray()
            },new SourceModel()
            {
                Id = IdS,
                Name = $"Источник {_id}",
                Resources = ResourceController.Resources.Skip(3).ToArray()
            },new SourceModel()
            {
                Id = IdS,
                Name = $"Источник {_id}",
                Resources = ResourceController.Resources.Take(2).ToArray()
            },new SourceModel()
            {
                Id = IdS,
                Name = $"Источник {_id}",
                Resources = ResourceController.Resources.Skip(1).Take(2).ToArray()
            },
        };

        [HttpGet("[action]")]
        public SourceModel[] GetAll()
        {
            return SourceModels.ToArray();
        }

        [HttpGet("[action]/{sourceId}")]
        public SourceModel Get(string sourceId)
        {
            return SourceModels.First(x => x.Id == sourceId);
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