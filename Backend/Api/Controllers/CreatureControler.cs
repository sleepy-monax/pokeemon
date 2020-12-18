using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Creatures;
using Microsoft.AspNetCore.Mvc;
using Model.Creature;

namespace Api.Controllers
{
    [ApiController]
    [Route("creatures")]
    public class CreatureControler : ControllerBase
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

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] Creature creature)
        {
            if (_creatureRepository.Update(id, creature))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Boolean> Post([FromBody] Creature creature)
        {
            return Ok(_creatureRepository.Create(creature.Id, creature));
        }
    }
}