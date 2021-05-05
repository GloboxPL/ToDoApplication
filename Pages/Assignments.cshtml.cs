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
            Init();

            return Page();
        }



        public IActionResult OnGetAllAssignments()
        {
            Init();
            AssignmentsToDisplay = new List<Assignment>(AssignmentsBase);

            return Page();
        }

        public IActionResult OnGetDoneAssignments()
        {
            Init();
            AssignmentsToDisplay = AssignmentsBase.Where(a => a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetNotDoneAssignments()
        {
            Init();
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetActiveAssignments()
        {
            Init();
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByDeadlineAscending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Deadline).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByDeadlineDescending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Deadline).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByImportanceAscending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.IsImportant).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByImportanceDescending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.IsImportant).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByNameAscending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Name).ToList();

            return Page();
        }

        public IActionResult OnGetSortedCollectionByNameDescending()
        {
            Init();
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Name).ToList();

            return Page();
        }

        private void Init()
        {
            AssignmentsBase = new List<Assignment>() { new Assignment() };
            AssignmentsBase = _data.GetAssignments(HttpContext);
            AssignmentsToDisplay = new List<Assignment>(AssignmentsBase);
        }
    }
}
