using System;
using System.Linq;
using Library.Models;
using Library.ReservationContext.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.ReservationContext
{
    public class ReservationController : Controller
    {
        readonly LibraryDbContext _context;

        public ReservationController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Post(Commands.MakeAReservationCommand command)
        {
            if(!_context.Books.Any(x => x.Isbn == command.Isbn))
                return NotFound();

            if(_context.Books.Any(book => book.Isbn == command.Isbn && !book.IsAvailableForReservation))
                return BadRequest();

            var bookForReservation = _context.Books.First(book => book.Isbn == command.Isbn);

            var reservation = new Reservation(command.AcademicRecord, bookForReservation);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }
    }
}