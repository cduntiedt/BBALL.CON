using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBALL.LIB.Services;
using BBALL.LIB.Helpers;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace BBALL.API.Controllers
{
    [Route("games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public IActionResult Get()
        {
            try
            {
                JArray parameters = new JArray();
                parameters.Add(ParameterHelper.CreateParameterObject("Season", SeasonHelper.DefaultSeason()));
                var test = DatabaseHelper.GetDocument("games", parameters).ToJson();
                return Ok(test);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
