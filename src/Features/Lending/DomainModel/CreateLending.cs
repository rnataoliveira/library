using System.Collections.Generic;

namespace Library.Features.Lending.DomainModel
{
    public class CreateLending 
    {
        public string LenderId { get; set; }

        public ICollection<string> Books { get; set; }
    }
}