using EntityFrameworkApp.Model;

namespace EntityFrameworkApp.Interfaces
{
    public interface ILanguagesRepository
    {

        public Task<Language> AddLanguage(Language language);
        public Task<ICollection<Language>> GetAllLanguages();

        public Task<Language> GetLanguageById(int id);

        public Task<ICollection<Language>> GetLanguageByName(string name,string description);

        public Task<Language> DeleteLanguage(int id);


    }
}
