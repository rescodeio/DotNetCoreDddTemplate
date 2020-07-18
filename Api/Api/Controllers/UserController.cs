using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IEnumerable<ISomeService> _someServices;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IEnumerable<ISomeService> someServices)
        {
            _logger = logger;
            _userRepository = userRepository;
            _someServices = someServices;
        }
        
        [HttpGet]
        [Route("api/v1/user/info")]
        public string GetInfo()
        {
            var response = "";
            foreach (var service in _someServices)
            {
                response += $"{service.GetInfo()}\n";
            }
            
            return response;
        }

        [HttpGet]
        [Route("api/v1/user/count")]
        public async Task<int> Count()
        {
            var all = await _userRepository.FindAll();
            return all.Count;
        }
        
        [HttpGet]
        [Route("api/v1/user/name/{name}")]
        public async Task<ICollection<UserEntity>> Count(string name)
        {
            var all = await _userRepository.FindAllWhereName(name);
            return all;
        }
        
        [HttpGet]
        [Route("api/v1/user/all")]
        public async Task<ICollection<UserEntity>> GetAll()
        {
            var all = await _userRepository.FindAll();
            return all;
        }
        
        [HttpGet]
        [Route("api/v1/user/generate/{name}")]
        public async Task Save(string name)
        {
            var userEntity = new UserEntity(name);
            await _userRepository.Save(userEntity);
        }
    }
}
