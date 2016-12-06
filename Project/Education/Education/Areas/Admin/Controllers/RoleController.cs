using Education.Areas.Admin.Model;
using Education.Areas.Admin.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : AdminBaseController
    {
        private RoleService roleService = new RoleService();
        // GET: Admin/Role
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            List<AspNetRole> roles = roleService.GetAllRole();
            return View(roles);
        }
        // GET: Admin/Lessions/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "system";
            AspNetRole role = roleService.GetRoleByPrimaryKey(id);
            if (role != null)
            {
                return View(role);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Lessions/ListUsers/1
        public ActionResult ListUsers(int id)
        {
            List<AppUser> appUsers = roleService.GetAllUserInRole(id);
            AspNetRole role = roleService.GetRoleByPrimaryKey(id);
            ViewData["RoleName"] = role.Name;
            return View(appUsers);
        }

        // GET: Admin/Lessions/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}