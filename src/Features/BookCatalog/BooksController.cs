using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.BookCatalog
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
            //Inicialmente mostra todos os livros
            if(string.IsNullOrEmpty(q))
                return View(_dbContext.Books);

            //Verifica se a busca é válida
            var books = _dbContext.Books.Where(book => 
                book.Author.Contains(q) ||
                book.Title.Contains(q) ||
                book.Isbn == q
            );

            //Se a busca retornar apenas um livro já redireciona para a página do livro
            if(books.Count() == 1)
                return RedirectToAction("Details", new {
                    Isbn = books.First().Isbn
                });
            
            return View(books);
        }
    }
}