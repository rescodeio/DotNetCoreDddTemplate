using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        public string Role { get; private set; }
        public string Password { get; private set; }
        public string Token { get; private set; }

        private UserEntity()
        {
        }

        public UserEntity(string name, string role, string password)
        {
            Id = new Guid();
            Name = name;
            Role = role;
            Password = password;
        }

        public UserEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void NoPassword()
        {
            Password = null;
        }
        
        public void UpdateToken(string token)
        {
            Token = token;
        }
    }
}