using Microsoft.EntityFrameworkCore;

namespace EF_Library
{
    public class UserRepository
    {



        public void SelectUser(int id)
        {
            using (var db = new AppContext())
            {
                var selUser = db.Users.Where(user => user.UserId == id); //выбор объекта по его индентификатору
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(selUser);
            }
        }
        //
        public List<User> SelectAllUser()
        {
            var selUser = new List<User>();
            using (var db = new AppContext())
            {
                selUser = db.Users.ToList();

                return selUser;

                foreach (var user in selUser)
                {
                    Console.WriteLine(user);
                }
            }
           

        }

        public void AddUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

            }
        }
        public void AddUsers(List<User> users)
        {
            using (var db = new AppContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();

            }
        }


        public void DeleteUser(User users)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(users);
                db.SaveChanges();

            }
        }

        //обновление имени пользователя(по Id)
        public void UpdateUserNameById(int id, string newUserName)
        {
            string selectName;
            using (var db = new AppContext())
            {
                var userById = db.Users.Where((user) => user.UserId == id).FirstOrDefault();
                userById.Name = newUserName;
                db.SaveChanges();
            }
        }
        ///  5.  Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool UserHasBook(string bookName)
        {
            using (var db = new AppContext())
            {
                var userBook = db.Users.Include(u => u.Books).Any(u => u.Name == bookName);
                return userBook;
            }


        }

        /// 6. Получать количество книг на руках у пользователя.
        public int CountUserBook(string UserName)
        {
            using (var db = new AppContext())
            {
                var countBook = db.Users
                                .Where(u => u.Name == UserName) // выбираем пользователя по имени
                                .SelectMany(u => u.Books) // получаем все книги пользователя
                                .Count(); // считаем количество книг
                return countBook;

            }
        }




    }
}
