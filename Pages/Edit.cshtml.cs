using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;

namespace ToDo.Pages
{
    public class EditModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;
        

        public EditModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public void OnGet()
        {
        }
    }
}
