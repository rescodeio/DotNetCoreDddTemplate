using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var guid = new Guid(id);
            var currentUserId = new Guid(User.Identity.Name);
            if (guid != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            var user =  _userService.GetById(guid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}