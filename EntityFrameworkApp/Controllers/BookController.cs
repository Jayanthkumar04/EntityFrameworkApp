using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkApp.Controllers
{
    [Route("Book/[controller]")]
    [ApiController]
    public class BookController(ApplicationDbContext _context,IBookRepository _repo):ControllerBase
    {

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {

            // _context.Book.Add(book);

            //await _context.SaveChangesAsync();

            

            var result = await _repo.AddBook(book);


            if(book.BookPrices != null && book.BookPrices.Any())
            {
                foreach(var bookPrice in book.BookPrices)
                {
                    
                     bookPrice.BookId = book.Id;
                    await _context.BookPrice.AddAsync(bookPrice);

                }

                await _context.SaveChangesAsync();
            }


            return Ok();
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> book)
        {
            //_context.Book.AddRange(book);

            //await _context.SaveChangesAsync();

            var result = await _repo.AddBooks(book);

            return Ok(book);
        }

        [HttpGet("GetBooks")]

        [ProducesResponseType(200, Type = typeof(ICollection<Book>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _repo.GetAllBooks();

            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

    }
}
