using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book 
    {
        [Key]
        public string Isbn { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string ShortDescription => Description.Substring(0, 200) + "...";

        public string Cover { get; set; }

        public string Author { get; set; }

        public int stock { get; set; }

    }
}