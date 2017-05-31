using System;
using System.Collections.Generic;
using Library.Features.BookCatalog.DomainModel;
using Library.Models;

namespace Library.Models
{
    public class Lending
    {
        public ICollection<Book> Books { get; set; }
        
        public Administrator Admin { get; set; }

        // public User user { get; set; }
    
        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }
        
    }
}