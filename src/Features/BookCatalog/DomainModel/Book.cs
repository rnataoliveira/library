using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Features.BookCatalog.DomainModel
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

        int _availableCopies;

        public int AvailableCopies 
        { 
            get { return _availableCopies; }
            set 
            { 
                _availableCopies = value; 
                
                //Se as copias disponiveis forem = 0 está disponivel para reserva, se não não.
                IsAvailableForReservation = _availableCopies <= 0;
            }
        }

        public bool IsAvailableForReservation { get; protected set; }
    }
}