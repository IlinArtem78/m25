﻿namespace EF_Library
{

    /// отношение "многие ко многим"
    /// ///

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }

}