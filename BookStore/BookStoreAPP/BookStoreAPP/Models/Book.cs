using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPP.Models
{
    public class Book
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public string IsbnNumber { get; set; }
    }
}
