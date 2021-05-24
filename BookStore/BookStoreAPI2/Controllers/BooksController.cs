using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ThreadLocal<BookRepository> books = new ThreadLocal<BookRepository>(() => new BookRepository());

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return books.Value.GetAllBooks();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            // var book = books.FirstOrDefault(x => x.Id == id);
            var book = books.Value.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public void CreateBook(Book book)
        {
            books.Value.CreateBook(book);
        }

        [HttpPut]
        public void EditBook(Book book)
        {
            books.Value.EditBook(book);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            books.Value.DeleteBook(id);
        }
    }
}
