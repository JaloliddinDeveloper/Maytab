using Maytab.Models.Foundations.Books;
using Maytab.Services.Foundations.Books;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Maytab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : RESTFulController
    {
        private readonly IBookService bookService;
        private readonly string uploadsFolder = "/var/www/files";
        private readonly string baseUrl = "http://35.232.97.243:8080";

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(IFormFile picture, IFormFile file, string name, int year, int klass, string size, string description, string language, string bookpath, LanguageType languagetype)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Main file not found or empty.");
            }

            if (picture == null || picture.Length == 0)
            {
                return BadRequest("Picture file not found or empty.");
            }

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            try
            {
                string fileGuid = Guid.NewGuid().ToString();
                string pictureGuid = Guid.NewGuid().ToString();

                string fileExtension = Path.GetExtension(file.FileName);
                string pictureExtension = Path.GetExtension(picture.FileName);

                var mainFilePath = Path.Combine(uploadsFolder, fileGuid + fileExtension);
                var pictureFilePath = Path.Combine(uploadsFolder, pictureGuid + pictureExtension);

                using (var stream = new FileStream(mainFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var stream = new FileStream(pictureFilePath, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                var fileRecord = new Book
                {
                    BookPath = $"{baseUrl}/files/{fileGuid + fileExtension}",
                    Picture = $"{baseUrl}/files/{pictureGuid + pictureExtension}",
                    Name = name,
                    Year = year,
                    Klass = klass,
                    Size=size,
                    Description=description,
                    Language=language,
                    LanguageType=languagetype
                };

                await this.bookService.AddBookAsync(fileRecord);

                return Created(fileRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error while processing the files.");
            }
        }
    }
}
