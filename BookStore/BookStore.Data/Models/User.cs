using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login { get; set; }
    }
}
