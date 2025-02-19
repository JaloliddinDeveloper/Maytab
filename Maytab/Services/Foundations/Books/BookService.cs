using Maytab.Brokers.Storages;
using Maytab.Models.Foundations.Books;

namespace Maytab.Services.Foundations.Books
{
    public class BookService: IBookService
    {
        private readonly IStorageBroker storageBroker;

        public BookService(IStorageBroker storageBroker)=>
            this.storageBroker = storageBroker;

        public async ValueTask<Book> AddBookAsync(Book book)=>
            await this.storageBroker.InsertBookAsync(book);
        
        public async ValueTask<IQueryable<Book>> GetAllBooksAsync()=>
            await this.storageBroker.SelectAllBooksAsync();
        
        public async ValueTask<Book> RetrieveBookByIdAsync(int id) =>
            await this.storageBroker.SelectBookByIdAsync(id);

        public async ValueTask<Book> RemoveBookByIdAsync(int id)
        {
            Book maybeBook=await this.storageBroker.SelectBookByIdAsync(id);
            return await this.storageBroker.DeleteBookAsync(maybeBook);
        }
    }
}
