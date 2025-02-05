using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Repository
{
    public class BookRepository(ApplicationDbContext _context) : IBookRepository
    {
        public async Task<Book> AddBook(Book book)
        {

            await _context.Book.AddAsync(book);

            await _context.SaveChangesAsync();

            return book;
        
        }

        public async Task<ICollection<Book>> AddBooks(List<Book> books)
        {

            var result =  _context.Book.AddRangeAsync(books);

            await _context.SaveChangesAsync();

            return books;

        }

        public async Task<ICollection<Book>> GetAllBooks()
        {
            var result = await _context.Book.Select(x=> new Book
            {
                Id = x.Id,
                Title = x.Title,
                Description=x.Description,
                NoOfPages=x.NoOfPages,
                LanguageId=x.LanguageId,
                Author=x.Author, 
                AuthorId=x.AuthorId,
                Language=x.Language,
                CreatedOn=x.CreatedOn,
                BookPrices=x.BookPrices

            }).AsNoTracking().ToListAsync();

            return result;
        
        }
    }
}
