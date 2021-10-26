using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBALL.LIB.Helpers;
using BBALL.LIB.Models;
using BBALL.LIB.Services;


namespace BBALL.API.Controllers
{
    [Route("stats")]
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

        [HttpPost]
        [Route("query")]
        public IActionResult Query(StatQuery query)
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
