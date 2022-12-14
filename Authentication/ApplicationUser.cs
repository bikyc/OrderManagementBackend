
namespace OrderManagement.Authentication
{
    public class ApplicationUser
    {
        public string Email { get; internal set; }
        public string SecurityStamp { get; internal set; }
        public string UserName { get; internal set; }
    }
}
