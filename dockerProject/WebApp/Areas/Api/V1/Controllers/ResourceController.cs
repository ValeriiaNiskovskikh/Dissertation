using System.Collections.Generic;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Api.V1.Controllers.Base;

namespace WebApp.Areas.Api.V1.Controllers
{
    public class ResourceController : BaseApiV1Controller
    {
        private static int _id;
        private static string IdR => $"r{_id++}";


        public static List<ResourceModel> Resources = new List<ResourceModel>()
        {
            new ResourceModel()
            {
                Id = IdR,
                Name = "Zn(цинк)"
            },
            new ResourceModel()
            {
                Id = IdR,
                Name = "Ca(кальций)"
            },
            new ResourceModel()
            {
                Id = IdR,
                Name = "Fe(железо)"
            },
            new ResourceModel()
            {
                Id = IdR,
                Name = "Cl(хлор)"
            },
            new ResourceModel()
            {
                Id = IdR,
                Name = "Mn(магний)"
            },
            new ResourceModel()
            {
                Id = IdR,
                Name = "S(сера)"
            },
        };

        [HttpGet("[action]")]
        public ResourceModel[] GetAll()
        {
            return Resources.ToArray();
        }

        [HttpGet("[action]/{sourceId}")]
        public object GetAll(string sourceId)
        {
            return "all by id";
        }
    }
}