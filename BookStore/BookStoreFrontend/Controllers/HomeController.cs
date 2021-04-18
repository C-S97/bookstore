using BookStoreFrontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreFrontend.Controllers
{
    public class HomeController : Controller
    {
        // URL from API
        string BaseUrl = "https://localhost:44331/";

        #region Books

        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            List<Book> Books = new List<Book>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Books");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Book list  
                    Books = JsonConvert.DeserializeObject<List<Book>>(BookResponse);

                }
                //returning the book list to view  
                return View(Books);
            }
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpPost]
        [ActionName("CreateBook")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                await client.PostAsJsonAsync("api/books", book);


                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [ActionName("CreateBook")]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpGet("{id}/edit")]
        [ActionName("EditBook")]
        public async Task<IActionResult> EditBook(int id)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                var Res = await client.GetAsync("api/books/" + id);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Book list  
                    Book bookRes = JsonConvert.DeserializeObject<Book>(BookResponse);
                    return View(bookRes);
                }
                return View();
            }
        }

        [HttpPost]
        [ActionName("EditedBook")]
        public async Task<IActionResult> EditedBook(Book book)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                await client.PutAsJsonAsync("api/books", book);

                return RedirectToAction("Index");
            }
        }

        [HttpGet("{id}/delete")]
        [ActionName("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                var res = await client.DeleteAsync("api/books/" + id);

                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region User

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UserLogin(string username, string password)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                await client.PutAsJsonAsync("api/user/login?username=" + username + "&password=" + password, "");

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> UserLogout(string username)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                await client.PutAsJsonAsync("api/user/logout?username=" + username, "");

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UserLogout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UserRegister(User user)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                user.Login = false;

                //Sending request to find web api REST service resource GetAllBooks using HttpClient  
                await client.PostAsJsonAsync("api/user", user);

                return RedirectToAction("Index");
            }
        }

        #endregion
    }
}
