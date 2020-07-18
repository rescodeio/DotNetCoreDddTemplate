using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }
        
        public async Task Save(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserEntity>> FindAll()
        {
            return await _context.Set<UserEntity>().ToListAsync();
        }

        public async Task<UserEntity> FindById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task Update(UserEntity user)
        {
            _context.Set<UserEntity>().Update(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(ICollection<UserEntity> users)
        {
            foreach (var user in users)
            {
                _context.Set<UserEntity>().Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UserEntity user)
        {
            _context.Set<UserEntity>().Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserEntity>> FindAllWhereName(string name)
        {
            return await _context.Users
                .Where(user => user.Name.Equals(name))
                .ToListAsync();
        }
    }
}