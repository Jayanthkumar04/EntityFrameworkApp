using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkApp.Controllers
{
    [Route("Book/[controller]")]
    [ApiController]
    public class BookController(ApplicationDbContext _context):ControllerBase
    {

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
             _context.Book.Add(book);

            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> book)
        {
            _context.Book.AddRange(book);

            await _context.SaveChangesAsync();

            return Ok(book);
        }

    }
}
