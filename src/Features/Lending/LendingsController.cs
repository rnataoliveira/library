using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Features.Account;
using Library.Features.BookCatalog.DomainModel;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.Lending
{
    [Route("lendings")]
    public class LendingsController : Controller 
    {
         readonly LibraryDbContext _context;
         readonly UserManager<ApplicationUser> _userManager;

        public LendingsController(LibraryDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [Route("start")]
        [HttpGet]
        public IActionResult Start() 
        {
            return View();
        }

        [Route("create")]
        [HttpGet]
        public async Task<IActionResult> Create(string username) 
        { 
            if(string.IsNullOrEmpty(username))
                return RedirectToAction("Start");

            var lender = await _userManager.FindByNameAsync(username);

            if(lender == null)
                return RedirectToAction("Start");

            //livros que o usuario atual reservou
            var reservedBooks = _context
                .Reservations
                .Where(res => res.User.Id == lender.Id)
                .Select(x => x.Book)
                .ToList();
            
            //livros que estão disponiveis para emprestimo
            var availableBooks = new List<Book>();

            foreach(Book book in reservedBooks) 
            {
                //busca a reserva da vez, para o livro 
                var reservation = _context.Reservations
                    .Where(b => b.Book.Isbn == book.Isbn)
                    .OrderByDescending(x => x.ReservationDate)
                    .FirstOrDefault();
                
                //verifica se o dono da reserva da vez é o usuario
                if(reservation.User.Id == lender.Id)
                    availableBooks.Add(reservation.Book);
            }

            return View();   
        }
    }
}
