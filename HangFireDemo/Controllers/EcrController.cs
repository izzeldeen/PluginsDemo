using BLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcrController : ControllerBase
    {
        private readonly IEnumerable<ITaskServices>  services;
        public EcrController(IEnumerable<ITaskServices> services)
        {
            this.services = services;
        }
        [HttpGet]
        public IActionResult Query([FromQuery] string serviceName)
        {
            return Ok(services.FirstOrDefault(x => x.ServiceName == serviceName).Pay("123678126371263721"));
        }

    }
}
