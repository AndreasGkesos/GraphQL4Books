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

        public Task<List<Book>> GetAll()
        {
            return _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetById(Guid bookId)
        {
            return await _dbContext.Books.Where(p => p.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task<Book> AddReview(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<ILookup<Guid, Book>> GetForAuthors(IEnumerable<Guid> authorIds)
        {
            var books = await _dbContext.Books.Where(b => authorIds.Contains(b.AuthodId)).ToListAsync();
            return books.ToLookup(x => x.AuthodId);
        }
    }
}
