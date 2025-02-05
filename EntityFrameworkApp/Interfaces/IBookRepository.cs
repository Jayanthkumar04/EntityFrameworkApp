using EntityFrameworkApp.Model;

namespace EntityFrameworkApp.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> AddBook(Book book);

        public Task<ICollection<Book>> AddBooks(List<Book> books);

        public Task<ICollection<Book>> GetAllBooks();
    }
}
