using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppContext db = AppContext.shared;

        public void UserLogin(string username, string password)
        {
            var user = db.Users.Where(user => user.Username == username).ToList().FirstOrDefault();
            if (user != null && user.Password == password)
            {
                user.Login = true;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public void UserLogout(string username)
        {
            var user = db.Users.Where(user => user.Username == username).ToList().FirstOrDefault();
            if (user != null)
            {
                user.Login = false;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public void UserRegister(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
