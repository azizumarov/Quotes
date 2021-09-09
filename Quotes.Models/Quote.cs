namespace Quotes.Models
{
    public class Quote : TrackedEntity
    {
        public string Author { get; set; }

        public string Category { get; set; }

        public string Value { get; set; }
    }
}