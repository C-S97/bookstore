using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        // List of books
        public List<Book> books = new List<Book>
        {
                new Book { Id = 0, Title = "Harry Potter und der Stein der Weisen", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3551557414", IsAvailable = false },
                new Book { Id = 1, Title = "Harry Potter und die Kammer des Schreckens", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55742-1", IsAvailable = false },
                new Book { Id = 2, Title = "Harry Potter und der Gefangene von Askaban", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55743-8", IsAvailable = false },
                new Book { Id = 3, Title = "Harry Potter und der Feuerkelch", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55744-5", IsAvailable = false },
                new Book { Id = 4, Title = "Harry Potter und der Orden des Phönix", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55745-2", IsAvailable = false },
                new Book { Id = 5, Title = "Harry Potter und der Halbblutprinz", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55746-9", IsAvailable = false },
                new Book { Id = 6, Title = "Harry Potter und die Heiligtümer des Todes", Author = "J K Rowling", PublicationYear = 2018, IsbnNumber = "978-3-551-55747-6", IsAvailable = false }
        };

        AppContext db = AppContext.shared;

        public void CreateBook(Book book)
        {
            db.Books.Add(new Book { Title = book.Title, Author = book.Author, PublicationYear = book.PublicationYear, IsbnNumber = book.IsbnNumber, IsAvailable = book.IsAvailable });
            db.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.ToList().FirstOrDefault(book => book.Id == id);
        }

        public void EditBook(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            db.Books.Remove(db.Books.Find(id));
            db.SaveChanges();
        }
    }
}
