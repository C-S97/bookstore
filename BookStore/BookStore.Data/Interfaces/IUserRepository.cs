using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Interfaces
{
    public interface IUserRepository
    {
        void UserLogin(string username, string password);
        void UserLogout(string username);
        void UserRegister(User user);
    }
}
