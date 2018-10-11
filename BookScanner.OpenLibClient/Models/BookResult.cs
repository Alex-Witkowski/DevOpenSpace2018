using System.Linq;

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
        public string pagination { get; set; }
        public Table_Of_Contents[] table_of_contents { get; set; }
        public Classifications classifications { get; set; }
        public string notes { get; set; }
        public int number_of_pages { get; set; }
        public Subject[] subjects { get; set; }
        public string by_statement { get; set; }
        public Publish_Places[] publish_places { get; set; }
        public Ebook[] ebooks { get; set; }

        public string AuthorsText
        {
            get
            {
                if (this.authors == null)
                {
                    return null;
                }
                return string.Concat(authors.Select(a => a.name).ToList());
            }
        }
    }

}
