using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);
        void CreateBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int id);
    }
}
