using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Users;
using Microsoft.AspNetCore.Mvc;
using Model.User;

namespace Backend.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {

        private IUserRepository _userRepository = new SqlServerUserRepository();
        
        [HttpGet]
        public ActionResult<IEnumerable<User>> Query()
        {
            return Ok(_userRepository.Query().Select(user => (User) user));
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            return Ok(_userRepository.Create(user));
        }
    }
}