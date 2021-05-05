using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;

namespace ToDo.Pages
{
    public class AddModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public string Color { get; set; }

        public AddModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Assignments");
        }
    }
}
