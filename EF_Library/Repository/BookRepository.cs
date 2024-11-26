namespace EF_Library
{
    public class BookRepository
    {
        /// <summary>
        /// С помощью полученных знаний дополните репозитории методами, которые позволят совершать следующие действия:
        ///  1. Получать список книг определенного жанра и вышедших между определенными годами.
        ///   2. Получать количество книг определенного автора в библиотеке.
        /// 3. Получать количество книг определенного жанра в библиотеке.
        ///  4.   Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        ///  5.  Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// 6. Получать количество книг на руках у пользователя.
        /// 7.  Получение последней вышедшей книги.
        /// 8.  Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        ///  9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <param name="id"></param>


        public void SelectBook(int id)
        {
            using (var db = new AppContext())
            {
                var selBook = db.Books.Where(book => book.BookId == id); //выбор объекта по его индентификатору
                db.SaveChanges();
            }
        }
        //
        public List<Book> SelectAllBook()
        {
            var selBook = new List<Book>();
            using (var db = new AppContext())
            {
                selBook = db.Books.ToList();
                db.SaveChanges();
                return selBook;
            }

        }

        public void AddBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();

            }
        }
        public void AddBooks(List<Book> books)
        {
            using (var db = new AppContext())
            {
                db.Books.AddRange(books);
                db.SaveChanges();

            }
        }




        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();

            }
        }


        //обновление года выпуска книги (по ID) 
        public void UpdateBookByYear(int id, int newBookYear)
        {
            string selectName;
            using (var db = new AppContext())
            {
                var bookById = db.Books.Where((book) => book.BookId == id).FirstOrDefault();
                bookById.Year = newBookYear;
                db.SaveChanges();
            }
        }
        public void TakeBookByUsers(Book book, List<User> users)
        {
            book.Users.AddRange(users);
        }

        ///Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> SearchByGenreAndYear(string NameGenre, int yearBook)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            using (var db = new AppContext())
            {
                var query2 = db.Books
                .Where(u => u.Genre == NameGenre && u.Year == yearBook)  // Фильтрует
                .ToList();
                return query2;
                foreach (var item in query2)
                {
                    Console.WriteLine(item);
                }
            }
        }

        // Получать количество книг определенного автора в библиотеке.
        public int CountBookByAuthor(string NameAuthor)
        {
            using (var db = new AppContext())
            {
                var countQuery = db.Books
                    .Count(u => u.Author == NameAuthor);
                return countQuery;
            }

        }
        /// Получать количество книг определенного жанра в библиотеке.
        public int CountBookByGenre(string NameGenre)
        {

            using (var db = new AppContext())
            {
                var countQuery = db.Books
                   .Where(book => book.Genre == NameGenre)
                    // Подсчёт количества книг
                    .Count();
                return countQuery;
            }
        }
        ///    Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public void FlagBookByAuthorAndName(string NameAuthor, string NameBook)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool flagBook;
            using (var db = new AppContext())
            {
                flagBook = db.Books.Any(u => u.Name == NameAuthor && u.Name == NameBook);

                if (flagBook)
                {
                    Console.WriteLine("Данная книга есть в библиотеке ");
                }
                else { Console.WriteLine("Данная книга отсутсвует в библиотеке"); }
            }

        }


        /// 7.  Получение последней вышедшей книги. 
        public Book GetBookByFinalYear()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            using (var db = new AppContext())
            {
                var query2 = db.Books
                 .OrderByDescending(u => u.Year) // Сортирует книги по году издания в порядке убывания
                 .FirstOrDefault();
                return query2;
            }
        }
        /// 8.  Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> SortedByAlphabet()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            using (var db = new AppContext())
            {
                var query = db.Books.OrderBy(u => u.Name).ToList();
                return query;
                foreach (var book in query)
                {
                    Console.WriteLine($"{book.Name} {book.Genre}  {book.Year} {book.Author}");
                }
            }
        }

        //  9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> SortedByFinalYear()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            using (var db = new AppContext())
            {
                var query = db.Books.OrderByDescending(b => b.Year).ToList();
                return query;
                foreach (var book in query)
                {
                    Console.WriteLine($"{book.Name} {book.Genre}  {book.Year} {book.Author}");
                }
            }
        }

    }

}

