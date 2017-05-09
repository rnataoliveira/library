using System;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.ReservationContext.DomainModel
{
    public class Reservation
    {
        public Reservation() { }

        public Reservation(string ar, Book book)
        {
            if (!Book.IsAvailableForReservation)
                throw new InvalidOperationException("Book is not available for reservation.");
            
            Number = Guid.NewGuid();
            AcademicRecord = ar;
            Book = book;
            ReservationDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Number { get; set; }

        public string AcademicRecord { get; set; }

        public Book Book { get; set; }

        public DateTime ReservationDate { get; protected set; }
    }
}