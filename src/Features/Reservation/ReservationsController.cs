using System;
using System.Linq;
using Library.Models;
using Library.Features.Reservation.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Library.Features.Account;
using System.Threading.Tasks;

namespace Library.Features.Reservation
{
    [Route("reservations")]
    [Authorize]
    public class ReservationsController : Controller
    {
        readonly LibraryDbContext _context;
        readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(LibraryDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<IActionResult> Post(Commands.MakeAReservationCommand command)
        {
            //se o livro não existe, não pode ser reservado -> not found(404)
            if(!_context.Books.Any(x => x.Isbn == command.Isbn))
                return NotFound();
            
            //se o livro não está disponivel para reserva, erro de validação -> bad request (400)
            if(_context.Books.Any(book => book.Isbn == command.Isbn && !book.IsAvailableForReservation))
                return BadRequest();
            
            //busca o livro que será reservado
            var bookForReservation = _context.Books.First(book => book.Isbn == command.Isbn);

            //busca o usuario que está logado
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            //cria uma reserva para o livro, com o Usuario e o livro
            var reservation = new DomainModel.Reservation(currentUser, bookForReservation);

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
            var currentUserId = _userManager.GetUserId(User);

            var reservation = _context.Reservations.FirstOrDefault(r => 
                r.Number == reservationNumber &&
                r.User.Id == currentUserId);
            
            if(reservation == null)
                return NotFound();

            return View("Reservation", reservation);
        }

        [Route("my-reservations")]
        public IActionResult MyReservations() 
        {
            var currentUserId = _userManager.GetUserId(User);

            var myReservations = _context.Reservations
                .Where(res => res.User.Id == currentUserId)
                .OrderByDescending(d => d.ReservationDate)
                .Select(r => r.Book);
                
            return View(myReservations);
        }
    }
}