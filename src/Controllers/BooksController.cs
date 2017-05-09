using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        readonly LibraryDbContext _dbContext;
        public BooksController(LibraryDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [Route("{isbn}")]
        public IActionResult Details(string isbn) 
        {
            //Busca o livro no banco de dados
            var foundBook = _dbContext.Books.FirstOrDefault(book => book.Isbn == isbn);

            // Se não encontrar retorna um 404
            if(foundBook == null)
                return NotFound();
                
            return View(foundBook);
        }

        public IActionResult Search(string q) 
        {
            if(string.IsNullOrEmpty(q))
                return View(_dbContext.Books);

            var books = _dbContext.Books.Where(book => 
                book.Author.Contains(q) ||
                book.Title.Contains(q) ||
                book.Isbn == q
            );

            if(books.Count() == 1)
                return RedirectToAction("Details", new {
                    Isbn = books.First().Isbn
                });

            return View(books);
        }

        public IActionResult Reservation(string book)
        {

            return View();
        }
    }
}