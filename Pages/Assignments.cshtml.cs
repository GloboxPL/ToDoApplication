using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using ToDo.Database;
using ToDo.Models;
using ToDo.Services;
using System.Threading.Tasks;

namespace ToDo.Pages
{
    public class AssignmentsModel : PageModel
    {
        private readonly Auth _auth;
        private readonly DataAccess _data;

        public IEnumerable<Assignment> AssignmentsBase { get; private set; } = new List<Assignment>();

        public IEnumerable<Assignment> AssignmentsToDisplay { get; set; } = new List<Assignment>();

        public AssignmentsModel(ToDoContext context)
        {
            _auth = new Auth(context);
            _data = new DataAccess(context);
        }

        public IActionResult OnGet()
        {
            AssignmentsBase = new List<Assignment>() { new Assignment() };
            AssignmentsBase = _data.GetAssignments(HttpContext);
            AssignmentsToDisplay = new List<Assignment>(AssignmentsBase);

            return Page();
        }

        public IActionResult OnGetAllAssignments()
        {
            AssignmentsToDisplay = new List<Assignment>(AssignmentsBase);

            return Page();
        }

        public IActionResult OnGetDoneAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetNotDoneAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetActiveAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByDeadlineAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Deadline).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByDeadlineDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Deadline).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByImportanceAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.IsImportant).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByImportanceDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.IsImportant).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByNameAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Name).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByNameDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Name).ToList();

            return Page();
        }

        public async Task<IActionResult> OnGetSignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
