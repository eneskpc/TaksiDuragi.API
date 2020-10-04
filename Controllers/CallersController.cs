using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaksiDuragi.API.Data;
using TaksiDuragi.API.Dtos;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallersController : ControllerBase
    {
        private readonly ICallerRepository _callerRepository;
        public CallersController(ICallerRepository callerRepository)
        {
            _callerRepository = callerRepository;
        }

        [Authorize(Policy = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetCallers()
        {
            string encodedToken = Request.Headers["Authorization"];
            var decodedToken = encodedToken.Replace("Bearer ", "").ResolveToken();

            if (decodedToken == null ||
                !int.TryParse(decodedToken.FirstOrDefault(dt => dt.Type == "nameid").Value, out int userId))
            {
                return Unauthorized();
            }

            var callers = await _callerRepository.GetCallers<Caller>(userId);

            if(callers == null)
            {
                return NoContent();
            }

            return Ok(callers);
        }
    }
}
