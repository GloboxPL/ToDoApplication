using System.Collections.Generic;
using System.Linq;
using ToDo.Models;
using ToDo.Models.DTO;
using ToDo.Services;

namespace ToDo.Database
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public UserDTO CreateUser(User user)
        {
            user = _context.Users.Add(user).Entity;
            return UserDTO.Map(user);
        }

        public UserDTO VerifyUser(string email, string password)
        {
            User user = _context.Users.Where(x => x.Email == email).SingleOrDefault();
            if (user == null) return null;
            if (Hashing.Check(user.Password, password))
            {
                return UserDTO.Map(user);
            }
            return null;
        }

        public UserDTO ReadUser(int id)
        {
            var user = _context.Users.Find(id);
            return UserDTO.Map(user);
        }

        public UserDTO UpdateUser(User user)
        {
            user = _context.Users.Update(user).Entity;
            return UserDTO.Map(user);
        }

        public Assignment CreateAssignment(Assignment assignment, int userId)
        {
            assignment.User = _context.Users.Find(userId);
            assignment = _context.Assignments.Add(assignment).Entity;
            return assignment;
        }

        public Assignment ReadAssignment(int id)
        {
            var assignment = _context.Assignments.Find(id);
            return assignment;
        }

        public IEnumerable<Assignment> ReadAllAssignmentsByUserId(int userId)
        {
            var assignments = _context.Assignments.Where(x => x.User.Id == userId).AsEnumerable();
            return assignments;
        }

        public Assignment UpdateAssignment(Assignment assignment, int userId)
        {
            assignment.User = _context.Users.Find(userId);
            _context.Assignments.Update(assignment);
            return assignment;
        }

        public void DeleteAssignment(int id)
        {
            _context.Assignments.Remove(_context.Assignments.Find(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}