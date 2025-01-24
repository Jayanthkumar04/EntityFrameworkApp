using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrencyController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        //[HttpGet("")]
        //public IActionResult GetAllCurrencies()
        //{

        //    var result = _context.Currency.ToList();

        //       return Ok(result);

        //}

        //[HttpGet("")]

        //public IActionResult GetAllCurrency()
        //{

        //    var result = (from currency in _context.Currency select currency).ToList();

        //    return Ok(result);

        //}
        //[HttpGet("")]
        //public async Task<IActionResult> GetAllCurrency()
        //{

        //    var result = await _context.Currency.ToListAsync();

        //    return Ok(result);

        //}

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrency()
        {

            var result = await (from currency in _context.Currency select currency).ToListAsync();

            return Ok(result);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            var result = await _context.Currency.FindAsync(id);

            return Ok(result);
        }

        //[HttpGet("{name}")]

        //public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        //{
        //    var result = await _context.Currency.FirstOrDefaultAsync(x => x.Title == name);

        //    return Ok(result);
        //}

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name, [FromQuery] string? description)
        {
            var result = await _context.Currency.FirstOrDefaultAsync(x => x.Title == name
                                                                     &&
                                                                     (string.IsNullOrEmpty(description) || x.Description == description)
            );

            return Ok(result);
        }

        [HttpPost("All")]
        public async Task<IActionResult> GetCurrenciessByIds([FromBody] List<int> ids)
        {
            var result = await _context.Currency.Where(x => ids.Contains(x.Id)).ToListAsync();

            return Ok(result);

        }

        [HttpGet("GettingRecords")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _context.Currency
                         .Select(x => new Currency
                         {
                             Id = x.Id,
                             Title = x.Title,
                         }).ToListAsync();

            return Ok(result);
        }


    }
}
