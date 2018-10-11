namespace BookScanner.OpenLibClient
{
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

}
