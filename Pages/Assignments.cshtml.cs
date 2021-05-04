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

        public IEnumerable<Assignment> AssignmentsBase { get; private set; }

        public IEnumerable<Assignment> AssignmentsToDisplay { get; set; }

        public AssignmentsModel(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public void OnGet()
        {
            AssignmentsBase = _toDoRepository.ReadAllAssignmentsByUserId(0);
            GetAllAssignments();
        }

        public void GetAllAssignments()
        {
            AssignmentsToDisplay = new List<Assignment>(AssignmentsBase);
        }

        public void GetDoneAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => a.IsDone).ToList();
        }

        public void GetNotDoneAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();
        }

        public void GetActiveAssignments()
        {
            AssignmentsToDisplay = AssignmentsBase.Where(a => !a.IsDone).ToList();
        }

        public void SortCollectionByDeadlineAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Deadline).ToList();
        }

        public void SortCollectionByDeadlineDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Deadline).ToList();
        }

        public void SortCollectionByImportanceAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.IsImportant).ToList();
        }

        public void SortCollectionByImportanceDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.IsImportant).ToList();
        }

        public void SortCollectionByNameAscending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderBy(a => a.Name).ToList();
        }

        public void SortCollectionByNameDescending()
        {
            AssignmentsToDisplay = AssignmentsToDisplay.OrderByDescending(a => a.Name).ToList();
        }
    }
}
