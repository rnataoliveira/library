using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        readonly List<Book> _database;

        public BooksController() 
        {
            _database = new List<Book>();
        }

        public IActionResult Details() {
            var book = new Book();
            book.Isbn = "978-1680502008";
            book.Subject = "Informática";
            book.Title = "Programming Elixir 1.3: Functional |> Concurrent |> Pragmatic |> Fun";
            book.Cover = "https://images-na.ssl-images-amazon.com/images/I/41jWVuRV30L._SX404_BO1,204,203,200_.jpg";
            book.Description = "Explore functional programming without the academic overtones (tell me about monads just one more time). Create concurrent applications, but get them right without all the locking and consistency headaches. Meet Elixir, a modern, functional, concurrent language built on the rock-solid Erlang VM. Elixir's pragmatic syntax and built-in support for metaprogramming will make you productive and keep you interested for the long haul. Maybe the time is right for the Next Big Thing. Maybe it's Elixir. This book is the introduction to Elixir for experienced programmers, completely updated for Elixir 1.3.";

            book.Authors = new Collection<Author>();

            var author = new Author();
            author.Name = "Dave";
            author.Surname = "Thomas";

            book.Authors.Add(author);

            return View(book);
        }
    }
}