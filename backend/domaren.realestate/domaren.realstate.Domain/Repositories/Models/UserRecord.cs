namespace domaren.realstate.Domain.Repositories.Models
{
    public class UserRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EMail { get; set; }
    }
}
