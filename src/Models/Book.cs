using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book 
    {
        public Book() { }

        public Book(string isbn, int copies)
        {
            Isbn = isbn;
            Copies = copies;
            AvailableCopies = copies;
        }

        [Key]
        public string Isbn { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string ShortDescription => Description.Substring(0, 200) + "...";

        public string Cover { get; set; }

        public string Author { get; set; }

        public int Copies { get; protected set; }

        public int AvailableCopies { get; set; }

        public bool IsAvailableForReservation => AvailableCopies == 0;
    }
}