using System.Collections.Generic;

namespace ToDo.Models
{
    public class User
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IList<Assignment> ToDos { get; set; } = new List<Assignment>();

        public User() { }

        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}