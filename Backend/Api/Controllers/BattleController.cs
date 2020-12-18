using System.Collections.Generic;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Model.Creature;


namespace Api.Controllers 
{
    [ApiController]
    [Route("battles")]
    public class BattleController : ControllerBase
    {
        private BattleService _service;

        public BattleController(BattleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Query()
        {
            return Ok(_service.GetAvailable());
        }
    }
}