using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Features.Account;
using Library.Features.BookCatalog.DomainModel;
using Library.Features.Lending.DomainModel;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Features.Lending.DomainModel
{
    public class Lending
    {
        public Lending(
            ApplicationUser lender, 
            ICollection<Book> books,
            ILendingExpirationService expirationService)
        {
            Lender = lender;
            Books = books;
            StartDate = DateTime.UtcNow;

            ExpirationDate = expirationService.ApplyExpirationPoliceFor(Lender, StartDate);
        }

        public ApplicationUser Lender { get; protected set; }
    
        public DateTime StartDate { get; protected set; }

        public DateTime ExpirationDate { get; protected set; }
        
        public ICollection<Book> Books { get; set; }
    }
}