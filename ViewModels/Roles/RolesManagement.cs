using System.Web.Security;

namespace Seller.ViewModels.Roles
{
    public class RolesManagement
    {
        public MembershipUserCollection Users { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalUsers { get; set; }

        public bool HasPreviousPage
        {
            get { return PageNumber > 1; }
        }

        public bool HasNextPage
        {
            get { return PageNumber < PageCount; }
        }
    }
}