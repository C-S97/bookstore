using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository users = new UserRepository();

        [HttpPut]
        [Route("login")]
        public void UserLogin(string username, string password)
        {
            users.UserLogin(username, password);
        }

        [HttpPut]
        [Route("logout")]
        public void UserLogout(string username)
        {
            users.UserLogout(username);
        }

        [HttpPost]
        public void UserRegister(User user)
        {
            users.UserRegister(user);
        }
    }
}
