using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Api
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserEntity> WithoutPasswords(this IEnumerable<UserEntity> users) 
        {
            return users?.Select(x => x.WithoutPassword());
        }

        public static UserEntity WithoutPassword(this UserEntity user) 
        {
            if (user == null)
            {
                return null;
            }

            user.NoPassword();
            return user;
        }
    }
}