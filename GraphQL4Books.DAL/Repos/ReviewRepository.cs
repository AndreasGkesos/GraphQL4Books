using GraphQL4Books.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL4Books.DAL.Repos
{
    public class ReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Review>> GetAll()
        {
            return _dbContext.Reviews.ToListAsync();
        }

        public async Task<Review> GetById(Guid reviewId)
        {
            return await _dbContext.Reviews.Where(p => p.Id == reviewId).FirstOrDefaultAsync();
        }

        public async Task<Review> AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<ILookup<Guid, Review>> GetForUsers(IEnumerable<Guid> userIds)
        {
            var reviews = await _dbContext.Reviews.Where(r => userIds.Contains(r.UserId)).ToListAsync();
            return reviews.ToLookup(x => x.UserId);
        }

        public async Task<ILookup<Guid, Review>> GetForBooks(IEnumerable<Guid> booksIds)
        {
            var reviews = await _dbContext.Reviews.Where(r => booksIds.Contains(r.BookId)).ToListAsync();
            return reviews.ToLookup(x => x.BookId);
        }
    }
}
