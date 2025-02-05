using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Repository
{
    public class LanguageRepository(ApplicationDbContext _context) : ILanguagesRepository
    {
        public async Task<Language> AddLanguage(Language language)
        {
            var result = await _context.Languages.AddAsync(language);

            _context.SaveChanges();
            
            return language;


        }

        public async Task<Language> DeleteLanguage(int id)
        {
            var lang = await _context.Languages.FindAsync(id);

            _context.Languages.Remove(lang);

            await _context.SaveChangesAsync();

            return lang;

        }

        public async Task<ICollection<Language>> GetAllLanguages()
        {

            var result = await _context.Languages.AsNoTracking().ToListAsync();

            return result;
        
        }

        public async Task<Language> GetLanguageById(int id)
        {

            //var result = await _context.Languages.FindAsync(id);

            var result = await _context.Languages.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            return result;

        }

        public async Task<ICollection<Language>> GetLanguageByName(string name, string description)
        {

            var result =await _context.Languages.Where(x => x.Title == name
                                                &&
                                       (string.IsNullOrEmpty(description) || x.Description == description)
                                                 
                                     ).ToListAsync();

            return result;
        }
    }
}
