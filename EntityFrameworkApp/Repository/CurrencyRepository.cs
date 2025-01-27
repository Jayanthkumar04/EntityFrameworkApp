using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Repository
{
    public class CurrencyRepository(ApplicationDbContext _context) : ICurrencyRepository
    {
        public async Task<Currency> AddCurrency(Currency currency)
        {
             _context.Add(currency);

            var result = _context.SaveChanges();

            return currency;
        }

        public async Task<Currency> EditCurrency(int id ,Currency currency)
        {
            var result = await _context.Currency.FirstOrDefaultAsync(x=>x.Id == id);

            result.Description = currency.Description;
            result.Title = currency.Title;

            await _context.SaveChangesAsync();

            return result;

        }

        public async Task<ICollection<Currency>> GetAllCurrency()
        {

            var result = await _context.Currency.ToListAsync();


            return result;
        }

        public async Task<ICollection<Currency>> GetAllCurrencyByIds(List<int> ids)
        {
            var result = await _context.Currency.Where(x => ids.Contains(x.Id)).ToListAsync();

            return result;
        }

        public async Task<Currency> GetCurrencyById(int id)
        {
            var result = await _context.Currency.FindAsync(id);

            return result;
        }

        public async Task<ICollection<Currency>> GetCurrencyByName(string name,string? description)
        {
            var result = await _context.Currency.Where(x => x.Title == name
                                                     && (string.IsNullOrEmpty(description) || x.Description == description)

                                                     ).ToListAsync();

            return result;
        }
    }
}
