using EntityFrameworkApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkApp.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<Currency> AddCurrency(Currency currency);
       Task<ICollection<Currency>> GetAllCurrency();

        Task<Currency> GetCurrencyById(int id);

        Task<ICollection<Currency>> GetCurrencyByName(string name,string? description);

       Task<ICollection<Currency>> GetAllCurrencyByIds(List<int> ids);

        Task<Currency> EditCurrency(int id , Currency currency);



    }
}
