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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoRepository _repo;

        public IndexModel(ILogger<IndexModel> logger, ToDoContext context)
        {
            _repo = new ToDoRepository(context);
            _logger = logger;
        }

        public void OnGet()
        {
            // example how to get/set db data in controller
            // _repo.CreateUser(new Models.User("John", "Kowalsky", "johny@mail.com", "passwordHash"));
            // _repo.SaveChanges();
        }
    }
}
