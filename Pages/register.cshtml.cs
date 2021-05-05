using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IActionResult OnPost()
        {
            return RedirectToPage("./Index");
        }
    }
}
