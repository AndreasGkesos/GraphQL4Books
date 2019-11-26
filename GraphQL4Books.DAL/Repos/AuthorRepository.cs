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

        public List<Author> GetAll()
        {
            return _dbContext.Authors.Include(b => b.Books).ToList();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.Include(b => b.Books).ToListAsync();
        }

        public  Author GetById(Guid authorId)
        {
            return _dbContext.Authors.Where(p => p.Id == authorId).Include(b => b.Books).FirstOrDefault();
        }

        public async Task<Author> GetByIdAsync(Guid authorId)
        {
            return await _dbContext.Authors.Where(p => p.Id == authorId).Include(b => b.Books).FirstOrDefaultAsync();
        }

        public Author AddReview(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            return author;
        }

        public async Task<Author> AddReviewAsync(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }
    }
}
