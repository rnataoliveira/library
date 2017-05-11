using System;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.Features.Reservation.DomainModel
{
    public class Reservation
    {
        public Reservation() { }

        public Reservation(string academicRecord, Book book)
        {
            if (!book.IsAvailableForReservation)
                throw new InvalidOperationException("Book is not available for reservation.");

            if(string.IsNullOrEmpty(academicRecord))
                throw new ArgumentException(nameof(academicRecord));
            
            Number = Guid.NewGuid();
            AcademicRecord = academicRecord;
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