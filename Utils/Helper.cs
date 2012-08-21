using System.Collections.Generic;
using System.Collections.ObjectModel;
using log4net;

namespace Seller.Utils
{
    public static class Helper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MvcApplication).FullName);

        public static readonly char[] SpaceSeparator = new[] {' '};

        public static readonly string EmptySelectItem = "select any";
        public static readonly string ShopId = "shopId";

        #region Nested type: Roles

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Moderator = "Moderator";
            public const string Shop = "Shop";
            public const string TrustedShop = "TrustedShop";

            public static readonly ReadOnlyCollection<string> AllRoles =
                new ReadOnlyCollection<string>(new List<string> {Administrator, Moderator, Shop, TrustedShop});

            public static readonly ReadOnlyCollection<string> TrustedRoles =
                new ReadOnlyCollection<string>(new List<string> {Administrator, Moderator, TrustedShop});

            public static readonly ReadOnlyCollection<string> ModeratorRoles =
                new ReadOnlyCollection<string>(new List<string> {Administrator, Moderator});

            public static readonly ReadOnlyCollection<string> ShopsRoles =
                new ReadOnlyCollection<string>(new List<string> {Shop, TrustedShop});

            public static void CheckRoles()
            {
                foreach (string role in AllRoles)
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