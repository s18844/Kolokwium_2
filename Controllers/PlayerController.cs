using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.Services;
using Kolokwium2.Wyjatki;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/[championships/1/teams]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerServices _dbService;
        public PlayerController(IPlayerServices dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeam(int id)
        {
            try
            {
                var wynik = _dbService.GetTeams(id);
                return Ok(wynik);
            }
            catch(DoNotFoundPlayer e)
            {
                return NotFound(e.Message);
            }
        }
    }
}