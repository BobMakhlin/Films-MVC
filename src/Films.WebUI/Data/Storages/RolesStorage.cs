using System.Collections.Generic;

namespace Films.WebUI.Data.Storages
{
    public class RolesStorage
    {
        public static IEnumerable<string> GetRoles()
        {
            return new List<string>
            {
                "User",
                "Admin"
            };
        }
    }
}
