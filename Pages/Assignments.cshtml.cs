using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;

namespace ToDo.Pages
{
    public class AssignmentsModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;

        public AssignmentsModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public void OnGet()
        {
        }
    }
}
