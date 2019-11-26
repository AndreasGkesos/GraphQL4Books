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

        public List<Review> GetAll()
        {
            return _dbContext.Reviews.Include(u => u.User).Include(b => b.Book).ToList();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _dbContext.Reviews.Include(u => u.User).Include(b => b.Book).ToListAsync();
        }

        public Review GetById(Guid reviewId)
        {
            return _dbContext.Reviews.Where(p => p.Id == reviewId).Include(u => u.User).Include(b => b.Book).FirstOrDefault();
        }

        public async Task<Review> GetByIdAsync(Guid reviewId)
        {
            return await _dbContext.Reviews.Where(p => p.Id == reviewId).Include(u => u.User).Include(b => b.Book).FirstOrDefaultAsync();
        }

        public Review AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public IEnumerable<Review> GetForUser(Guid userId)
        {
            var reviews = _dbContext.Reviews.Where(r => r.UserId == userId).Include(u => u.User).Include(b => b.Book).ToList();
            return reviews;
        }

        public async Task<IEnumerable<Review>> GetForUserAsync(Guid userId)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.UserId == userId).Include(u => u.User).Include(b => b.Book).ToListAsync();
            return reviews;
        }

        public IEnumerable<Review> GetForBooks(IEnumerable<Guid> booksIds)
        {
            var reviews = _dbContext.Reviews.Where(r => booksIds.Contains(r.BookId)).Include(u => u.User).Include(b => b.Book).ToList();
            return reviews;
        }

        public async Task<IEnumerable<Review>> GetForBooksAsync(IEnumerable<Guid> booksIds)
        {
            var reviews = await _dbContext.Reviews.Where(r => booksIds.Contains(r.BookId)).Include(u => u.User).Include(b => b.Book).ToListAsync();
            return reviews;
        }

        public Book GetForBook(Guid bookId)
        {
            var book = _dbContext.Books.Where(b => b.Id == bookId).Include(a => a.Author).FirstOrDefault();
            return book;
        }

        public async Task<Book> GetForBookAsync(Guid bookId)
        {
            var book = await _dbContext.Books.Where(b => b.Id == bookId).Include(a => a.Author).FirstOrDefaultAsync();
            return book;
        }
    }
}
