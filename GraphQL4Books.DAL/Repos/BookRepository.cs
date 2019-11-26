using GraphQL4Books.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL4Books.DAL.Repos
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.Include(a => a.Author).Include(r => r.Reviews).ToList();
        }

        public Task<List<Book>> GetAllAsync()
        {
            return _dbContext.Books.Include(a => a.Author).Include(r => r.Reviews).ToListAsync();
        }

        public Book GetById(Guid bookId)
        {
            return _dbContext.Books.Where(p => p.Id == bookId).Include(a => a.Author).Include(r => r.Reviews).FirstOrDefault();
        }

        public async Task<Book> GetByIdAsync(Guid bookId)
        {
            return await _dbContext.Books.Where(p => p.Id == bookId).Include(a => a.Author).Include(r => r.Reviews).FirstOrDefaultAsync();
        }

        public Book AddReview(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public async Task<Book> AddReviewAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public IEnumerable<Book> GetForAuthor(Guid authorId)
        {
            var books = _dbContext.Books.Where(b => b.AuthodId == authorId).Include(a => a.Author).ToList();
            return books;
        }

        public async Task<IEnumerable<Book>> GetForAuthorAsync(Guid authorId)
        {
            var books = await _dbContext.Books.Where(b => b.AuthodId == authorId).Include(a => a.Author).ToListAsync();
            return books;
        }
    }
}
