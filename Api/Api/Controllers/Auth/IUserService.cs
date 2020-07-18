using System;
using System.Collections.Generic;
using Domain;

namespace Api
{
    public interface IUserService
    {
        UserEntity Authenticate(string username, string password);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(Guid id);
    }
}