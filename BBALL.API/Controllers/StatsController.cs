using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBALL.LIB.Models;
using BBALL.LIB.Services;

namespace BBALL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult Post(StatQuery query)
        {
            try
            {
                return Ok(StatService.Query(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
