namespace EF_Library.View
{
    public class InputData
    {
        private User InputDataUser()
        {
            var user = new User(); 
            Console.WriteLine("Введите имя пользоваетля библиотеки");
            Console.WriteLine();
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите электронную почту");
            Console.WriteLine();
            user.Email = Console.ReadLine();
            return user; 
        }
        public List<User> InputDataUsers()
        {
            Console.WriteLine("Введите количество пользователей библиотеки");
            int count = Convert.ToInt32(Console.ReadLine());

            List<User> users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                users.Add(InputDataUser());
            }

            return users;
        }

         private Book InputDataBook()
         {
            var book = new Book();
            Console.WriteLine("Введите название книги");
            Console.WriteLine();
            book.Name = Console.ReadLine();
            Console.WriteLine("Введите жанр книги");
            Console.WriteLine();
            book.Genre = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            Console.WriteLine();
            book.Author = Console.ReadLine();
            Console.WriteLine("Введите год издания книги: "); 
            Console.WriteLine();
            book.Year = int.Parse(Console.ReadLine());
            return book;

        }

        public List<Book> InputDataBooks()
        {
            Console.WriteLine("Введите количество книг");
            int count = Convert.ToInt32(Console.ReadLine());

            List<Book> books = new List<Book>();

            for (int i = 0; i < count; i++)
            {
                books.Add(InputDataBook());
            }

            return books;
        }





    }
}
