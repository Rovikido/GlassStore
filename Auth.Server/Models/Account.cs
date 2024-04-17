namespace Auth.Server.Models
{
    public class Account
    {
        public Guid id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role[] Role { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}
