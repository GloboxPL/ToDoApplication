using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Database
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

    }
}