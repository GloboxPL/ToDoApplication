using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Pages
{
    public class EditModel : PageModel
    {
        private readonly Auth _auth;

        public Assignment Assignment { get; set; }

        public EditModel(ToDoContext context)
        {
            _auth = new Auth(context);
        }

        public IActionResult OnGet()
        {
            Assignment = new Assignment();
            //Assignment = _toDoRepository.ReadAssignment(0);

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Assignments");
        }
    }
}
