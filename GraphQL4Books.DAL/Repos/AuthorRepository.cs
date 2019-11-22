using GraphQL4Books.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL4Books.DAL.Repos
{
    public class AuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Author>> GetAll()
        {
            return _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetById(Guid authorId)
        {
            return await _dbContext.Authors.Where(p => p.Id == authorId).FirstOrDefaultAsync();
        }

        public async Task<Author> AddReview(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }
    }
}
