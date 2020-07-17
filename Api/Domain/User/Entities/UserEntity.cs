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

        private UserEntity()
        {
        }

        public UserEntity(string name)
        {
            Id = new Guid();
            Name = name;
        }

        public UserEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}