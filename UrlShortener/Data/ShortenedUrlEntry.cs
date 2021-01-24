namespace UrlShortener.Data
{
    public class ShortenedUrlEntry
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Url { get; set; }

        public string ShortUrl { get; set; }
    }
}
