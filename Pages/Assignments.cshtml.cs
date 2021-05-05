using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using ToDo.Database;
using ToDo.Models;

namespace ToDo.Pages
{
    public class AssignmentsModel : PageModel
    {
        private readonly IToDoRepository _toDoRepository;

        public IEnumerable<Assignment> AssignmentsBase { get; private set; } = new List<Assignment>();

        public IEnumerable<Assignment> AssignmentsToDisplay { get; set; } = new List<Assignment>();

        public AssignmentsModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult OnGet()
        {
            AssignmentsBase = new List<Assignment>() { new Assignment() };
            //AssignmentsBase = _toDoRepository.ReadAllAssignmentsByUserId(0);
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
    }
}
