using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Creatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Model.Creature;

namespace Api.Controllers
{
    
    [ApiController]
    [Route("creatures")]
    public class MonsterControler : ControllerBase
    {
        
        private ICreatureRepository _creatureRepository = new SqlServerCreatureRepository();

        [HttpGet]
        public ActionResult<IEnumerable<ICreature>> Query()
        {
            return Ok(_creatureRepository.Query().Select(creature => (Creature) creature));
        }
        
        [HttpGet]
        [Route("user/{id}")]
        public ActionResult<IEnumerable<ICreature>> GetByUser(int id)
        {
            return Ok(_creatureRepository.GetByUser(id).Select(creature => (Creature) creature));
        }
    }
}