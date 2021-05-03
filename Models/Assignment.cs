using System;

namespace ToDo.Models
{
    public class Assignment
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public string Color { get; set; }
        public User User { get; set; }

        public Assignment() { }

        public Assignment(string name, string description, bool isImportant, DateTime deadline, string color, User user)
        {
            Name = name;
            Description = description;
            IsImportant = isImportant;
            Deadline = deadline;
            Color = color;
            User = user;
        }
    }
}