using GraphQL4Books.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL4Books.DAL.Repos
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.Include(r => r.Reviews).ToList();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.Include(r => r.Reviews).ToListAsync();
        }

        public User GetById(Guid userId)
        {
            return _dbContext.Users.Where(p => p.Id == userId).Include(r => r.Reviews).FirstOrDefault();
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _dbContext.Users.Where(p => p.Id == userId).Include(r => r.Reviews).FirstOrDefaultAsync();
        }

        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User newUser, User oldUser)
        {
            oldUser.Name = newUser.Name;
            oldUser.Email = newUser.Email;

            await _dbContext.SaveChangesAsync();

            return oldUser;
        }
    }
}
