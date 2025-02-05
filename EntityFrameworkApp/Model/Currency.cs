using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Model
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    
        public string Description { get; set; }

        public ICollection<BookPrice>? BookPrices { get; set; }

    }
}
