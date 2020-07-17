using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/v1/user")]
        public void Get()
        {
            _logger.LogWarning("yeah");
        }
        
        [HttpGet]
        [Route("api/v1/user2")]
        public string Get2()
        {
            _logger.LogWarning("yeah2");
            return "Ok";
        }
    }
}
