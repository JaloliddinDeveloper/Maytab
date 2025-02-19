using Maytab.Models.Foundations.Books;
using Microsoft.EntityFrameworkCore;

namespace Maytab.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Book> Books { get; set; }

        public async ValueTask<Book> InsertBookAsync(Book book) =>
           await InsertAsync(book);

        public async ValueTask<IQueryable<Book>> SelectAllBooksAsync() =>
            await SelectAllAsync<Book>();

        public async ValueTask<Book> SelectBookByIdAsync(int bookId) =>
            await SelectAsync<Book>(bookId);

        public async ValueTask<Book> UpdateBookAsync(Book book) =>
            await UpdateAsync(book);

        public async ValueTask<Book> DeleteBookAsync(Book book) =>
            await DeleteAsync(book);
    }
}
