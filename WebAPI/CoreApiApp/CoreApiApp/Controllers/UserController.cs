using DataModel.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;

namespace CoreApiApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }
        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return UserService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(string id)
        {
            var user = UserService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {
            UserService.Create(user);

            return CreatedAtRoute(new { id = user.UserID.ToString() }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, UserModel userIn)
        {
            var user = UserService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            UserService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = UserService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            UserService.Remove(user.UserID);

            return NoContent();
        }

    }
}