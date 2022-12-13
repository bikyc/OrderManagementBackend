

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Authentication
{
    public class ApplicationUser : DbContext
    {
        public string Email { get; internal set; }
        public string SecurityStamp { get; internal set; }
        public string UserName { get; internal set; }
    }
}
