using System;
using System.Linq;
using Library.Models;
using Library.Features.Reservation.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.Reservation
{
    [Route("reservations")]
    public class ReservationsController : Controller
    {
        readonly LibraryDbContext _context;

        public ReservationsController(LibraryDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Post(Commands.MakeAReservationCommand command)
        {
            //se o livro não existe, não pode ser reservado -> not found(404)
            if(!_context.Books.Any(x => x.Isbn == command.Isbn))
                return NotFound();
            
            //se o livro não está disponivel para reserva, erro de validação -> bad request (400)
            if(_context.Books.Any(book => book.Isbn == command.Isbn && !book.IsAvailableForReservation))
                return BadRequest();
            
            //busca o livro que será reservado
            var bookForReservation = _context.Books.First(book => book.Isbn == command.Isbn);

            //cria uma reserva para o livro, com o RA do Usuario e o livro
            var reservation = new DomainModel.Reservation(command.AcademicRecord, bookForReservation);

            //salva o livro no banco de dados
            _context.Reservations.Add(reservation);

            //commit
            _context.SaveChanges();

            TempData["ReservationSuccess"] = "Reserva criada com sucesso!";
            
            return RedirectToAction($"{nameof(Get)}", new { ReservationNumber = reservation.Number });
        }

        [Route("{reservationNumber}")]
        public IActionResult Get(Guid reservationNumber) 
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Number == reservationNumber);
            if(reservation == null)
                return NotFound();

            return View("Reservation", reservation);
        }

        [Route("my-reservations")]
        public IActionResult MyReservations(Reservation.Commands.MakeAReservationCommand user) {
            var myReservations = _context.Reservations.OrderByDescending(d => d.ReservationDate).Where(r => r.AcademicRecord == "1600041").Select(r => r.Book);
            return View(myReservations);
        }
    }
}