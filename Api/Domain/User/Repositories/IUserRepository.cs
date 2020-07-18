using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserRepository : ICrudRepository<Guid, UserEntity>
    {
        Task<ICollection<UserEntity>> FindAllWhereName(string name);
    }
}