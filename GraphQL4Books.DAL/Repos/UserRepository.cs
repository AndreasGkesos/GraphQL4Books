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

        public Task<List<User>> GetAll()
        {
            return _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid userId)
        {
            return await _dbContext.Users.Where(p => p.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<User> AddReview(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
