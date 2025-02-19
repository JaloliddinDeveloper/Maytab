using Maytab.Models.Foundations.Books;

namespace Maytab.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Book> InsertBookAsync(Book book);
        ValueTask<IQueryable<Book>> SelectAllBooksAsync();
        ValueTask<Book> SelectBookByIdAsync(int bookId);
        ValueTask<Book> UpdateBookAsync(Book book);
        ValueTask<Book> DeleteBookAsync(Book book);
    }
}
