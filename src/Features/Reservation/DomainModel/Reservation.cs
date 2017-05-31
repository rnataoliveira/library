using System;
using System.ComponentModel.DataAnnotations;
using Library.Models;
using Library.Features.BookCatalog.DomainModel;
using Library.Features.Account;

namespace Library.Features.Reservation.DomainModel
{
    public class Reservation
    {
        public Reservation() { }

        public Reservation(ApplicationUser user, Book book)
        {
            if (!book.IsAvailableForReservation)
                throw new InvalidOperationException("Book is not available for reservation.");
                
            Number = Guid.NewGuid();
            User = user;
            Book = book;
            ReservationDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Number { get; set; }
        
        public ApplicationUser User { get; set; }

        public Book Book { get; set; }

        public DateTime ReservationDate { get; protected set; }
    }
}