using System;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using static Library.Features.BookCatalog.DomainModel.Book;

namespace Library.Features.Lending
{
    public class LendingController : Controller 
    {
         readonly LibraryDbContext _context;

        public LendingController(LibraryDbContext context)
        {
            _context = context;
        }
        
        [Route("")]
        public IActionResult Lending() 
        {
            return View();
        }
    }
}