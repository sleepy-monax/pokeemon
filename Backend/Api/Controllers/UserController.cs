using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Users;
using Microsoft.AspNetCore.Mvc;
using Model.User;

namespace Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository = new SqlServerUserRepository();

        [HttpGet]
        public ActionResult<IEnumerable<User>> Query()
        {
            return Ok(_userRepository.Query().Select(user => (User)user));
        }

        [HttpGet]
        [Route(template: "{id}")]
        public ActionResult<User> GetById(int id)
        {
            IUser user = (User)_userRepository.Get(id);
            return user != null ? (ActionResult<User>)Ok(user) : NotFound();
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            return Ok(_userRepository.Create(user));
        }

        [HttpPut]
        [Route(template: "{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (_userRepository.Update(id, user))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}

