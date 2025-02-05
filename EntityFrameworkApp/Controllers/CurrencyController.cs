using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
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
        private readonly ICurrencyRepository _repo;

        public CurrencyController(ICurrencyRepository repo)
        {
            _repo = repo;
            
        }

        [HttpPost("AddCurrency")]
        [ProducesResponseType(200,Type=typeof(Currency))]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCurrency([FromBody] Currency currency)
        {
            var CurrAdd = _repo.AddCurrency(currency);

            return Created();
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
        [ProducesResponseType(200,Type=typeof(Currency))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllCurrency()
        {

            //var result = await (from currency in _context.Currency select currency).ToListAsync();

            var result = await _repo.GetAllCurrency();
            if (result != null)
                return Ok(result);
            else
                return NoContent();

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200,Type=typeof(Currency))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            //var result = await _context.Currency.FindAsync(id);
            var result = await _repo.GetCurrencyById(id);
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        //[HttpGet("{name}")]

        //public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        //{
        //    var result = await _context.Currency.FirstOrDefaultAsync(x => x.Title == name);

        //    return Ok(result);
        //}

        

        [HttpGet("{name}")]
        [ProducesResponseType(200,Type=typeof(Currency))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name, [FromQuery] string? description)
        {
            //var result = await _context.Currency.FirstOrDefaultAsync(x => x.Title == name
            //                                                         &&
            //                                                         (string.IsNullOrEmpty(description) || x.Description == description)        

            var result = await _repo.GetCurrencyByName(name, description);
            if (result != null)
                return Ok(result);
            else return NoContent();
        }

        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(Currency))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllCurrencyByIds([FromBody] List<int> ids)
        {
            var result = await _repo.GetAllCurrencyByIds(ids);
            if (result != null)
                return Ok(result);

            else return NoContent();

        }

        /*
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
        */

        [HttpPut("edit{id}")]


        public async Task<IActionResult> EditCurrency([FromRoute] int id ,[FromBody] Currency currency)
        {
            var result = await _repo.EditCurrency(id,currency);

            return Ok(result);

        }


    }
}
