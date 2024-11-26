using EF_Library.View;

namespace EF_Library.Models
{
    public class ModelsBookUser
    {
        //Реализуйте с помощью одной из связей возможность получения книги «на руки» пользователем
        //(для этого придется удалить таблицы из БД, либо воспользоваться EnsureDeleted).
        //А также придумайте, как можно добавить в книгу автора и жанр книги.
       
        public UserRepository? repository { get; set; } = new UserRepository();
        public BookRepository? bookRepository {  get; set; } = new BookRepository();
        public ModelsBookUser(List<User> users, List<Book> books)
        {
            //вносим данные пользователеей
            /*
            var user1 = new User() { Name = "Pavel", Email = "testc@gmail.com" };
            var user2 = new User() { Name = "Sergey", Email = "sergeyc@gmail.com" };
            var user3 = new User() { Name = "Maria", Email = "s_maria@gmail.com" };
            //вносим данные о книгах 
            var book1 = new Book() { Name = "Преступление и наказание", Author = "Достаевский", Genre = "роман", Year = 1986 };
            var book2 = new Book() { Name = "Мы", Author = "Замятин", Genre = "антиутопия", Year = 1987 };
            var book3 = new Book() { Name = "Метро", Author = "Глуховский", Genre = "роман", Year = 2018 };

            */
          //  UserRepository repository = new UserRepository();
          //  BookRepository bookRepository = new BookRepository();


            try
            {
       
                var users_group1 = new List<User>();
                users_group1.Add(users[0]);
                users_group1.Add(users[1]);
                users_group1.Add(users[2]);
         
                var users_group2 = new List<User>();
                users_group2.Add(users[3]);
                users_group2.Add(users[4]);
                users_group2.Add(users[5]);
                var all_user = users;

                bookRepository.TakeBookByUsers(books[0], users_group1);
                bookRepository.TakeBookByUsers(books[1], users_group1);
                bookRepository.TakeBookByUsers(books[2], users_group2);

    

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }





        }
    }
}
