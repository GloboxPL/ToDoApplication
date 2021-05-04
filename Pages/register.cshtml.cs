using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDo.Database;

namespace ToDo.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;

        }

        public void OnGet()
        {
            // example how to get/set db data in controller
            // _repo.CreateUser(new Models.User("John", "Kowalsky", "johny@mail.com", "passwordHash"));
            // _repo.SaveChanges();
        }
    }
}
