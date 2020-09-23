using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaksiDuragi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }
    }
}
