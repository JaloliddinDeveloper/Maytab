namespace Maytab.Models.Foundations.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Klass { get; set; } 
        public string Picture { get; set; } 
        public double Size { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
