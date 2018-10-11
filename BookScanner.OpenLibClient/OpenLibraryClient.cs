using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var res = JsonConvert.DeserializeObject<Dictionary<string, BookResult>>(result);
            return result;
        }
    }

    public class BookResult
    {
        public Publisher[] publishers { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public Identifiers identifiers { get; set; }
        public Cover cover { get; set; }
        public string publish_date { get; set; }
        public string key { get; set; }
        public Author[] authors { get; set; }
    }

    public class Identifiers
    {
        public string[] isbn_13 { get; set; }
        public string[] openlibrary { get; set; }
    }

    public class Cover
    {
        public string small { get; set; }
        public string large { get; set; }
        public string medium { get; set; }
    }

    public class Publisher
    {
        public string name { get; set; }
    }

    public class Author
    {
        public string url { get; set; }
        public string name { get; set; }
    }

}
