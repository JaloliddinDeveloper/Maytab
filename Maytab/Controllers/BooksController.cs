using Maytab.Services.Foundations.Books;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Maytab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController:RESTFulController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }
    }
}
