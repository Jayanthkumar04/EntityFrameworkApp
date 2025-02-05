using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApp.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool  IsActive { get; set; }
        public DateOnly CreatedOn { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Language? Language { get; set; }
        public Author? Author { get; set; }
        public ICollection<BookPrice> BookPrices { get; set; }
    }
}
