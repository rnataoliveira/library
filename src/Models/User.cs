namespace Library.Models

{
    public class User
    {
        public string RA { get; set; }

        public string Password { get; set; }
    }

    public class Teacher : User
    {

    }

    public class Student : User
    {
        
    }
}