using System.Linq;

namespace Library.Models 
{
    public static class Seed 
    {
        public static void SeedDatabase(this LibraryDbContext context)
        {
            if(context.Books.Any()) return;

            var book = new Book();
            book.Isbn = "978-1680502008";
            book.Subject = "Informática";
            book.Title = "Programming Elixir 1.3: Functional |> Concurrent |> Pragmatic |> Fun";
            book.Cover = "https://images-na.ssl-images-amazon.com/images/I/41jWVuRV30L._SX404_BO1,204,203,200_.jpg";
            book.Description = "Explore functional programming without the academic overtones (tell me about monads just one more time). Create concurrent applications, but get them right without all the locking and consistency headaches. Meet Elixir, a modern, functional, concurrent language built on the rock-solid Erlang VM. Elixir's pragmatic syntax and built-in support for metaprogramming will make you productive and keep you interested for the long haul. Maybe the time is right for the Next Big Thing. Maybe it's Elixir.";
            book.Author = "Thomas, Dave";

            var book1 = new Book();
            book1.Isbn = "9788575224625";
            book1.Subject = "Informática";
            book1.Title = "Python Fluente";
            book1.Cover = "https://images-na.ssl-images-amazon.com/images/I/51Ov4P3XiEL._SX357_BO1,204,203,200_.jpg";
            book1.Description = "A simplicidade de Python permite que você se torne produtivo rapidamente, porém isso muitas vezes significa que você não estará usando tudo que ela tem a oferecer. Com este guia prático, você aprenderá a escrever um código Python eficiente e idiomático aproveitando seus melhores recursos – alguns deles, pouco conhecidos. O autor Luciano Ramalho apresenta os recursos essenciais da linguagem e bibliotecas de Python mostrando como você pode tornar o seu código mais conciso, mais rápido e mais legível ao mesmo tempo. ";
            book1.Author = "Ramalho, Luciano";

            var book2 = new Book();
            book2.Isbn = "9781491914397";
            book2.Subject = "Informática";
            book2.Title = "ASP.NET MVC 5 with Bootstrap and Knockout.js: Building Dynamic, Responsive Web Applications";
            book2.Cover = "https://images-na.ssl-images-amazon.com/images/I/517yImP8zeL._SX379_BO1,204,203,200_.jpg";
            book2.Description = "Bring dynamic server-side web content and responsive web design together to build websites that work and display well on any resolution, desktop or mobile. With this practical book, you’ll learn how by combining the ASP.NET MVC server-side language, the Bootstrap front-end framework, and Knockout.js—the JavaScript implementation of the Model-View-ViewModel pattern.";
            book2.Author = "Munro, Jamie";
            
            var book3 = new Book();
            book3.Isbn = "9781449320317";
            book3.Subject = "Informática";
            book3.Title = "Programming ASP.NET MVC 4: Developing Real-World Web Applications with ASP.NET MVC";
            book3.Cover = "https://images-na.ssl-images-amazon.com/images/I/51dpPiy-OQL._SX377_BO1,204,203,200_.jpg";
            book3.Description = "Get up and running with ASP.NET MVC 4, and learn how to build modern server-side web applications. This guide helps you understand how the framework performs, and shows you how to use various features to solve many real-world development scenarios you’re likely to face. In the process, you’ll learn how to work with HTML, JavaScript, the Entity Framework, and other web technologies.";
            book3.Author = "Chadwick, Jess";

            context.Books.Add(book);
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            
            context.SaveChanges();

        }
    }
}