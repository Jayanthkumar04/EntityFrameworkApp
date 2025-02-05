using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    

    }
}
