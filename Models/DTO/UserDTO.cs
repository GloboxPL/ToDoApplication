namespace ToDo.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public UserDTO(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public static UserDTO Map(User user)
        {
            return new UserDTO(user.Id, user.Name, user.Surname, user.Email);
        }
    }
}