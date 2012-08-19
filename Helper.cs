namespace Seller
{
    public static class Helper
    {
        #region Nested type: Roles

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Moderator = "Moderator";
            public const string Magazine = "Shop";

            public static void CheckRoles()
            {
                foreach (string role in new[] {Administrator, Moderator, Magazine})
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