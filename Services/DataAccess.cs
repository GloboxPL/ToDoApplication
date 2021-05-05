using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ToDo.Database;
using ToDo.Models;

namespace ToDo.Services
{
    public class DataAccess
    {
        private readonly IToDoRepository _repo;

        public DataAccess(ToDoContext context)
        {
            _repo = new ToDoRepository(context);
        }

        public IEnumerable<Assignment> GetAssignments(HttpContext httpContext)
        {
            int id = GetUserId(httpContext.User);
            var assignments = _repo.ReadAllAssignmentsByUserId(id);
            return assignments;
        }
        public Assignment GetOneAssignment(int id)
        {
            var assignments = _repo.ReadAssignment(id);
            return assignments;
        }

        public void SaveAssignment(Assignment assignment, HttpContext httpContext)
        {
            int userId = GetUserId(httpContext.User);
            if (assignment.Id == 0)
            {
                _repo.CreateAssignment(assignment, userId);
            }
            else
            {
                _repo.UpdateAssignment(assignment, userId);
            }
            _repo.SaveChanges();
        }

        private int GetUserId(ClaimsPrincipal user)
        {
            int id = Int32.Parse(user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return id;
        }
    }
}