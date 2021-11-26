using Microsoft.AspNetCore.Http.Features;

namespace Server.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }


        public Users()
        {
            IsAdmin = false;
        }
    }
}