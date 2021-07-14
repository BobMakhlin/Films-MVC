using Films.WebUI.Data.Storages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Films.WebUI.Helpers.Initializers
{
    public class UsersDbInitializer
    {
        #region Fields
        UserManager<IdentityUser> m_usersManager;
        RoleManager<IdentityRole> m_rolesManager;
        #endregion

        public UsersDbInitializer
        (
            UserManager<IdentityUser> usersManager,
            RoleManager<IdentityRole> rolesManager
        )
        {
            m_usersManager = usersManager;
            m_rolesManager = rolesManager;
        }


        public async Task SeedAsync()
        {
            var roles = RolesStorage.GetRoles();
            var users = UsersStorage.GetUsers();

            foreach (var role in roles)
            {
                await CreateRoleAsync(role);
            }

            foreach (var user in users)
            {
                await CreateUserAsync(user);
            }
        }

        private async Task CreateRoleAsync(string roleName)
        {
            var target = await m_rolesManager.FindByNameAsync(roleName);
            if (target != null) return;

            var role = new IdentityRole { Name = roleName };
            await m_rolesManager.CreateAsync(role);
        }
        private async Task CreateUserAsync(IdentityUserPoco user)
        {
            var target = await m_usersManager.FindByEmailAsync(user.IdentityUser.Email);
            if (target != null) return;

            await m_usersManager.CreateAsync(user.IdentityUser, user.Password);
            await m_usersManager.AddToRolesAsync(user.IdentityUser, user.Roles);
        }
    }
}
