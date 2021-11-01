using BBALL.LIB.Helpers;
using BBALL.LIB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBALL.AWS.Controllers
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult Post(StatEndpoint endpoint)
        {
            try
            {
                string doc = DatabaseHelper.GenerateDocument(StatsHelper.BaseURL + endpoint.url + "/", endpoint.parameters);
                return Ok(doc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
