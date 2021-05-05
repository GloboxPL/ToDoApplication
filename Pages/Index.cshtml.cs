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
        private readonly IToDoRepository _toDoRepository;
        public string Email { get; set; }
        public string Password { get; set; }

        public IndexModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public void OnGet()
        {

        }
    }
}
