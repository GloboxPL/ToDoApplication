using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;
using ToDo.Models;

namespace ToDo.Pages
{
    public class EditModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;

        public Assignment Assignment { get; set; }

        public EditModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
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
