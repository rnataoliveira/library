namespace Library.Models
{
    public class Administrator
    {
        public string Admin { get; set; }

        public string Password { get; set; }

    }

    public class Employee : Administrator
    {

    }

    public class Librarian : Administrator
    {
        
    }

    
}