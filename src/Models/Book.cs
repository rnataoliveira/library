using System.Collections.Generic;

namespace Library.Models
{
    public class Book 
    {
        public string Isbn;

        public string Title;

        public string Subject;

        public string Description;

        public string Cover;

        public ICollection<Author> Authors;

    }
}