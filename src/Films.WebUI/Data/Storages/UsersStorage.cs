using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Films.WebUI.Data.Storages
{
    public class IdentityUserPoco
    {
        public IdentityUser IdentityUser { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public static class UsersStorage
    {
        public static IEnumerable<IdentityUserPoco> GetUsers()
        {
            var users = new List<IdentityUserPoco>
            {
                new IdentityUserPoco
                {
                    IdentityUser = new IdentityUser
                    {
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                        EmailConfirmed = true,
                    },
                    Password = "Qwerty123!@#",
                    Roles = new List<string> { "Admin", "User" }
                }
            };

            return users;
        }
    }
}
