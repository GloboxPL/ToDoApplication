using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Pages
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly Auth _auth;
        private readonly DataAccess _data;

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }

        public EditModel(ToDoContext context)
        {
            _auth = new Auth(context);
            _data = new DataAccess(context);
        }

        public IActionResult OnGet(int? itemid)
        {
            if (itemid == null)
            {
                Deadline = DateTime.Now.AddDays(1);
            }
            else
            {
                var assignment = _data.GetOneAssignment((int)itemid);
                Name = assignment.Name;
                Description = assignment.Description;
                IsImportant = assignment.IsImportant;
                IsDone = assignment.IsDone;
                Deadline = assignment.Deadline;
            }
            return Page();
        }

        public IActionResult OnPost(int? itemid)
        {
            var assignment = new Assignment(Name, Description, IsImportant, Deadline, null, null);
            if (itemid != null) assignment.Id = (int)itemid;
            _data.SaveAssignment(assignment, HttpContext);
            return RedirectToPage("./Assignments");
        }
    }
}
