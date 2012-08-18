using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Seller.ViewModels.Roles;

namespace Seller.Controllers
{
    [Authorize(Roles = Helper.Administrator)]
    public class RolesController : Controller
    {
        //
        // GET: /Roles/
        public ActionResult Index(int? page, int? pageSize)
        {
            int usersPerPage = pageSize ?? 20;
            int pageNumber = page ?? 1;
            if (usersPerPage > 0)
            {
                int totalUsers;
                return View(new RolesManagement
                                {
                                    Users = Membership.GetAllUsers(pageNumber - 1, usersPerPage, out totalUsers),
                                    PageCount = (totalUsers + usersPerPage - 1)/usersPerPage,
                                    PageSize = usersPerPage,
                                    PageNumber = pageNumber,
                                    TotalUsers = totalUsers
                                });
            }
            else
            {
                MembershipUserCollection users = Membership.GetAllUsers();
                return View(new RolesManagement
                                {
                                    Users = users,
                                    PageCount = 1,
                                    PageSize = 0,
                                    PageNumber = 1,
                                    TotalUsers = users.Count
                                });
            }
        }

        public ActionResult BrowseRole(string role)
        {
            if (role == null)
            {
                return View("Error");
            }
            return View(null, null, role);
        }

        [HttpPost]
        public ActionResult RemoveChecked(string role, string[] selectedUsers)
        {
            if (selectedUsers == null)
            {
                return RedirectToAction("Index");
            }

            foreach (string selectedUser in selectedUsers)
            {
                Roles.RemoveUserFromRole(selectedUser, role);
            }

            return RedirectToAction("Index");
        }

        public ViewResult UserDetails(Guid user)
        {
            MembershipUser membershipUser = Membership.GetUser(user);
            if (membershipUser == null)
            {
                return View("Error");
            }
            return View(membershipUser);
        }

        [HttpPost]
        public ActionResult UpdateUserRoles(Guid userGuid, string[] selectedRoles)
        {
            MembershipUser user = Membership.GetUser(userGuid);
            if (user == null)
            {
                return View("Error");
            }

            ISet<string> newSelectedRoles = new HashSet<string>(selectedRoles ?? new string[0]);
            ISet<string> currSelectedRoles = new HashSet<string>(Roles.GetRolesForUser(user.UserName));

            foreach (string role in Roles.GetAllRoles())
            {
                if (newSelectedRoles.Contains(role))
                {
                    if (!currSelectedRoles.Contains(role))
                    {
                        Roles.AddUserToRole(user.UserName, role);
                    }
                }
                else
                {
                    if (currSelectedRoles.Contains(role))
                    {
                        Roles.RemoveUserFromRole(user.UserName, role);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}