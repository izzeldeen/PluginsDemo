using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using BLogic;
using Autofac.Core;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        
        public ServicesController()
        {
        }


        [HttpPost]
        public IActionResult RegisterServices([FromForm] string dllName)
        {
            (from t in Assembly.LoadFrom(@dllName).GetTypes()
             select t).ToList().ForEach(delegate (Type a)
             {
                 Type inter = a.GetInterfaces().FirstOrDefault();
                 ServiceCollectionProvider.ServiceCollections = ServiceCollectionProvider.RegisterService(inter, a);
             });

            return Ok("Added");

        }
    }
}
