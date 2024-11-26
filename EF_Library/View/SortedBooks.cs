namespace EF_Library
{
    public class SortedBooks
    {
        public SortedBooks(BookRepository bookRepository, UserRepository userRepository)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Выберите тип сортировки книг: ");
            Console.WriteLine();
            Console.WriteLine(" 1. Получать список книг определенного жанра и вышедших между определенными годами.\r\n   2. Получать количество книг определенного автора в библиотеке.\r\n  3. Получать количество книг определенного жанра в библиотеке.\r\n  4.   Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.\r\n 5.  Получение последней вышедшей книги.\r\n  6.  Получение списка всех книг, отсортированного в алфавитном порядке по названию.\r\n  7. Получение списка всех книг, отсортированного в порядке убывания года их выхода. \r\n 8. Получать булевый флаг о том, есть ли определенная книга на руках у пользователя. \r\n  9.Получать количество книг на руках у пользователя. ");
            byte num = byte.Parse(Console.ReadLine());
            Console.WriteLine("Выбранный тип {0}", num);
            try
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Введите интерсующий жанр книги");
                        string NameGenre = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Введите интерсующий год выпуска книги");
                        int yearBook = int.Parse(Console.ReadLine());
                        var tempBookList = bookRepository.SearchByGenreAndYear(NameGenre, yearBook);
                        break;
                    case 2:
                        Console.WriteLine("Введите интерсующего автора книги");
                        string AuthorName = Console.ReadLine();
                        Console.WriteLine();
                        var tempCount1 = bookRepository.CountBookByAuthor(AuthorName);
                        Console.WriteLine(tempCount1);
                        break;
                    case 3:
                        Console.WriteLine("Введите интерсующий жанр книги");
                        var GenreName = Console.ReadLine();
                        Console.WriteLine();
                        var tempCount2 = bookRepository.CountBookByGenre(GenreName);
                        Console.WriteLine(tempCount2);
                        break;
                    case 4:
                        // Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке. 
                        Console.WriteLine("Введите интерсующее название книги");
                        var temp1 = Console.ReadLine();
                        Console.WriteLine("Введите интерсующего автора книги");
                        var temp2 = Console.ReadLine();
                        bookRepository.FlagBookByAuthorAndName(temp1, temp2);
                        break;
                    case 5:
                        // Получение последней вышедшей книги.\r\n 
                        var bookLast = bookRepository.GetBookByFinalYear();
                        Console.WriteLine(bookLast);
                        break;
                    case 6:
                        // Получение списка всех книг, отсортированного в алфавитном порядке по названию.
                        var temp3 = bookRepository.SortedByAlphabet();
                        break;
                    case 7:
                        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
                        var temp4 = bookRepository.SortedByFinalYear();
                        break;
                    case 8:
                        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя. \r\n  

                        Console.WriteLine("Введите название книги:  ");
                        string? bookName = Console.ReadLine();
                        var temp5 = userRepository.UserHasBook(bookName);
                        if (temp5 == true)
                        {
                            Console.WriteLine("Книга на руках у пользователя");
                        }
                        else
                        {
                            Console.WriteLine("У пользователя нет данной книги");
                        }
                        break;
                    case 9:
                        //9.Получать количество книг на руках у пользователя. ");
                        Console.WriteLine("Введите имя пользователя:  ");
                        string? bookNameUser = Console.ReadLine();
                        var temp6 = userRepository.CountUserBook(bookNameUser);
                        Console.WriteLine(temp6);
                        break;

                    default:
                        Console.WriteLine("Введено неверное число! Повторител попытку");
                        break;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}
