using System.Collections.Generic;
using ToDo.Models;
using ToDo.Models.DTO;

namespace ToDo.Database
{
    public interface IToDoRepository
    {
        UserDTO CreateUser(User user);
        UserDTO VerifyUser(string email, string passwordHash);
        UserDTO ReadUser(int id);
        UserDTO UpdateUser(User user);
        Assignment CreateAssignment(Assignment assignment);
        Assignment ReadAssignment(int id);
        IEnumerable<Assignment> ReadAllAssignmentsByUserId(int userId);
        Assignment UpdateAssignment(Assignment assignment);
        void DeleteAssignment(int id);
        void SaveChanges();
    }
}