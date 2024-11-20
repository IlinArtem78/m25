using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Library
{
    public class BookRepository
    {

        //следующие действия: выбор объекта из БД по его идентификатору,
        //выбор всех объектов, добавление объекта в БД и его удаление из БД.
        //А также специфичные методы: обновление имени пользователя (по Id) и обновление года выпуска книги (по Id).
        
        public void SelectBook(int id)
        {
            using (var db = new AppContext())
            {
                var selBook = db.Books.Where(book => book.Id == id); //выбор объекта по его индентификатору
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

        public void AddBook(Book books)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(books);
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

        //обновление имени пользователя(по Id)
        public void UpdateBookById(int id, string newBookName)
        {
            string selectName; 
            using (var db = new AppContext())
            {
                var bookById = db.Books.Where((book) => book.Id == id).FirstOrDefault();
                 bookById.Name = newBookName;
                db.SaveChanges();
            }
        }





    }
}
