using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApp.Model
{
    public class BookPrice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public int? Amount { get; set; }
        public Book? Book { get; set; }
        public  Currency? Currency { get; set; }
    }
}
