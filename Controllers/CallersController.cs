using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaksiDuragi.API.Data;

namespace TaksiDuragi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallersController : ControllerBase
    {
        private ICallerRepository _callerRepository;
        public CallersController(ICallerRepository callerRepository)
        {
            _callerRepository = callerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCallers()
        {
            return Ok(new string[] { "value1", "value2" });
        }
    }
}
