using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookScanner.OpenLibClient
{
    public class OpenLibraryClient
    {
        private HttpClient _httpClient;

        public OpenLibraryClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://openlibrary.org/api/");
        }

        public async Task<string> GetBookByIsbnAsync(string isbn)
        {
            var result = await _httpClient.GetStringAsync($"books?bibkeys=ISBN:{isbn}&format=json&jscmd=data").ConfigureAwait(false);
            return result;
        }
    }
}
