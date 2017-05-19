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
        
        [Route("home")]
        public IActionResult Home(Reservation.Commands.MakeAReservationCommand user) {
            var lastReservations = _context.Reservations.OrderByDescending(d => d.ReservationDate).Where(r => r.AcademicRecord == "1600041").Select(r => r.Book).Take(4);
            return View(lastReservations);
        }
    }
}