using BookStoreAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPP.Services
{
    public class API
    {
        public static API shared = new API();
        private HttpClient Client;

        private API()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            Client = new HttpClient(clientHandler);
            Client.BaseAddress = new Uri("http://10.3.35.108:5000/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<Book>> GetBooks()
        {
            HttpResponseMessage booksResponse = await Client.GetAsync("books");
            return JsonConvert.DeserializeObject<ObservableCollection<Book>>(await booksResponse.Content.ReadAsStringAsync());
        }

        public async Task AddBook(Book book)
        {
            await Client.PostAsJsonAsync("books", book);
        }

        public async Task DeleteBook(Book book)
        {
            await Client.DeleteAsync("books/" + book.Id);
        }

        public async Task GetBook()
        {

        }
    }
}
