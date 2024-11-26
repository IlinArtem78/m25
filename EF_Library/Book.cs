namespace EF_Library
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();

    }
}
