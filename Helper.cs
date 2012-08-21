using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seller
{
    public static class Helper
    {
        public static readonly char[] SpaceSeparator = new[] {' '};

        #region Nested type: Roles

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Moderator = "Moderator";
            public const string Shop = "Shop";

            public static readonly ReadOnlyCollection<string> RolesArray =
                new ReadOnlyCollection<string>(new List<string> {Administrator, Moderator, Shop});

            public static void CheckRoles()
            {
                foreach (string role in RolesArray)
                {
                    if (!System.Web.Security.Roles.RoleExists(role))
                    {
                        System.Web.Security.Roles.CreateRole(role);
                    }
                }
            }
        }

        #endregion
    }
}