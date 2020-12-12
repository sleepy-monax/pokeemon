using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.UserItems;
using Microsoft.AspNetCore.Mvc;
using Model.UserItems;

namespace Api.Controllers
{
    [ApiController]
    [Route("userItems")]
    public class UserItemsController : ControllerBase
    {

        private IUserItemsRepository _userItemsRepository = new SqlServerUserItemsRepository();

        [HttpGet]
        public ActionResult<IEnumerable<UserItem>> Query()
        {
            return Ok(_userItemsRepository.Query().Cast<UserItem>());
        }

        [HttpGet]
        [Route(template: "{id:int}")]
        public ActionResult<UserItem> GetById(int id)
        {
            IUserItems userItems = (UserItem) _userItemsRepository.Get(id);
            return userItems != null ? (ActionResult<UserItem>) Ok(userItems) : NotFound();
        }
        
        [HttpPost]
        public ActionResult<UserItem> Create([FromBody] UserItem userItem)
        {
            return Ok(_userItemsRepository.Create(userItem));
        }

        [HttpDelete]
        [Route(template: "{id}")]
        public ActionResult Put(int id, [FromBody] UserItem userItem)
        {
            if (_userItemsRepository.Update(id, userItem))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}