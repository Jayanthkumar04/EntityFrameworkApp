using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Model
{
    public class Language
    {
        [Key]
        public int Id { get; set; } 

        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<Book>? Books { get; set; }

    }
}
