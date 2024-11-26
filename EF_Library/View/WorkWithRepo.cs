using EF_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EF_Library.View
{
  public class WorkWithRepo
    {
        public WorkWithRepo(List<Book> books, List<User> users) 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //реализация отношений книг и пользователей
            var userAddBooks = new ModelsBookUser(users, books);
            Console.WriteLine("Выберите необходимые действия: ");
            Console.WriteLine("1 - добавление пользователей и книг, \r\n 2 - добавление пользователя \r\n 3 - удаление пользователя" +
                "\r\n 4 - выбор пользователя по id \r\n 5 - выбор всех пользователей \r\n 6 - обновление имени пользователя(по Id)" +
                 "\r\n 7 - добавление книги \r\n 8 - удаление книги " +
                "\r\n 9 - выбор книги по ID \r\n  10 - выбор всех книг  \r\n 11 - обновление года выпуска книги (по ID)");
            byte num = byte.Parse(Console.ReadLine());  
            Console.WriteLine("Выбраный номер {0}", num);
            Console.WriteLine(); 
            try { 
            switch(num)
            {
                case 1:
                    userAddBooks.bookRepository.AddBooks(books);
                    userAddBooks.repository.AddUsers(users);
                    break;
                    case 2:
                     Console.WriteLine("Добавим пользователя {0}", users[0]);
                    userAddBooks.repository.AddUser(users[0]);
                    break;
                    case 3:
                    Console.WriteLine("Введите id пользователя"); 
                    int i = int.Parse(Console.ReadLine()); 
                     var userTemp = users.Find(x => x.UserId == i);
                     userAddBooks.repository.DeleteUser(userTemp);  
                    break;
                    case 4:
                        Console.WriteLine("Введите id пользователя");
                        int id = int.Parse(Console.ReadLine());
                        userAddBooks.repository.SelectUser(id);
                        break;
                    case 5:
                        userAddBooks.repository.SelectAllUser();   
                    break;
                    case 6:
                        //обновление имени пользователя(по Id)
                        Console.WriteLine("Введите id пользователя, которого хотите заменить");
                        var id_user = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое имя пользователя");
                        var new_name = Console.ReadLine();
                        userAddBooks.repository.UpdateUserNameById(id_user, new_name); 
                    break;
                    case 7:
                        Console.WriteLine("Добавим пользователя {0}", books[0]);
                        userAddBooks.bookRepository.AddBook(books[0]);
                        break;
                    case 8:
                        Console.WriteLine("Введите id книги");
                        int n = int.Parse(Console.ReadLine());
                        var bookTemp = books.Find(x => x.BookId == n);
                        userAddBooks.bookRepository.DeleteBook(bookTemp);
                        break;  
                    case 9:
                        Console.WriteLine("Введите id книги");
                        int book_id = int.Parse(Console.ReadLine());
                        userAddBooks.bookRepository.SelectBook(book_id);
                        break;
                    case 10:
                        userAddBooks.bookRepository.SelectAllBook();
                    break;
                    case 11:
                        Console.WriteLine("Введите id книги");
                        int T_book_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новый год выпуска книги"); 
                        int newBookYear = int.Parse(Console.ReadLine());
                        userAddBooks.bookRepository.UpdateBookByYear(T_book_id, newBookYear);   

                        break;
                   
                    default: 
                    Console.WriteLine("Выбарн неверный номер!!"); 
                    break;
            }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
