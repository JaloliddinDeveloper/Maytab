using Maytab.Models.Foundations.Books;

namespace Maytab.Services.Foundations.Books
{
    public interface IBookService
    {
        ValueTask<Book> AddBookAsync(Book book);
        ValueTask<IQueryable<Book>> GetAllBooksAsync();
        ValueTask<Book> RetrieveBookByIdAsync(int id); 
        ValueTask<Book> RemoveBookByIdAsync(int id);
    }
}
