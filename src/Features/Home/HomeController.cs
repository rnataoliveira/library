using System;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using static Library.Features.BookCatalog.DomainModel.Book;

namespace Library.Features.Home
{
    public class HomeController : Controller 
    {
        readonly LibraryDbContext _context;

        public HomeController(LibraryDbContext context)
        {
            _context = context;
        }
        
        [Route("")]
        public IActionResult Home() 
        {
            var lastReservations = _context
                .Reservations
                .OrderByDescending(d => d.ReservationDate)
                .Select(reservation => reservation.Book)
                .GroupBy(book => book.Isbn)
                .Take(4)
                .Select(group => group.FirstOrDefault());

            return View(lastReservations);
        }
    }
}