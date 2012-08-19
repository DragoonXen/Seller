using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Seller.Controllers
{
    [Authorize(Roles = Helper.Roles.Administrator)]
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
                ViewBag.Users = Membership.GetAllUsers(pageNumber - 1, usersPerPage, out totalUsers);
                ViewBag.PageCount = (totalUsers + usersPerPage - 1)/usersPerPage;
                if (pageNumber <= ViewBag.PageCount)
                {
                    ViewBag.PageNumber = pageNumber;
                }
                else
                {
                    ViewBag.PageNumber = 1;
                    ViewBag.Users = Membership.GetAllUsers(0, usersPerPage, out totalUsers);
                }
                ViewBag.PageSize = usersPerPage;
                ViewBag.TotalUsers = totalUsers;
            }
            else
            {
                MembershipUserCollection users = Membership.GetAllUsers();
                ViewBag.Users = users;
                ViewBag.PageCount = 1;
                ViewBag.PageSize = 0;
                ViewBag.PageNumber = 1;
                ViewBag.TotalUsers = users.Count;
            }
            ViewBag.HasPreviousPage = ViewBag.PageNumber > 1;
            ViewBag.HasNextPage = ViewBag.PageNumber < ViewBag.PageCount;
            return View();
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