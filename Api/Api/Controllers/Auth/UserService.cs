using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class UserService : IUserService
    {
        // TODO: Add Context conection
        private readonly List<UserEntity> _users = new List<UserEntity>
        { 
            new UserEntity("admin", "admin", Role.Admin),
            new UserEntity("user", "user", Role.User),
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserEntity Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Name == username && x.Password == password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.UpdateToken(tokenHandler.WriteToken(token));

            return user.WithoutPassword();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _users.WithoutPasswords();
        }

        public UserEntity GetById(Guid id) 
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user.WithoutPassword();
        }
    }
}