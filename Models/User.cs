using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDo.Models
{
    public class User
    {
        public int Id { get; protected set; }

        [Required]  
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]  
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]  
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]  
        [DataType(DataType.Password)]  
        [Display(Name = "Password")]
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