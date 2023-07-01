using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using BLogic;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IServiceProvider serviceProvider;
        public ServicesController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        [HttpPost]
        public IActionResult RegisterServices([FromForm] string dllName)
        {
            (from t in Assembly.LoadFrom(@dllName).GetTypes()
                 //  where t.IsSubclassOf(typeof(ITaskServices))
             select t).ToList().ForEach(delegate (Type a)
             {
                 //if (a is ITaskServices)
                 //{
                 Type inter = a.GetInterfaces().FirstOrDefault();
                 ServiceCollectionProvider.Services.AddTransient(inter, a);
                 // }


             });

            return Ok("Added");

        }
    }
}
