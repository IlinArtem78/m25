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

            //реализация отношений книг и пользователей
            var userAddBooks = new ModelsBookUser(users, books);
            Console.WriteLine("Выберите необходимые действия: ");
            Console.WriteLine("1 - добавление пользователей и книг, \r\n 2 - добавление пользователя \r\n 3 - удаление пользователя" +
                "\r\n 4 - выбор пользователя по id \r\n 5 - выбор всех пользователей \r\n 6 - удаление пользователя " +
                "\r\n 7 - обновление имени пользователя(по Id) \r\n 8 -  ");
            
        }
    }
}
