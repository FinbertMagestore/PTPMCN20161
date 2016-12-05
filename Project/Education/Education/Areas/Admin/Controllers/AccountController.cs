using Education.Areas.Admin.Model;
using Education.Areas.Admin.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    // User: Huy
    // TODO: CRUD người dùng

    [Authorize(Roles = "Admin")]
    public class AccountController : AdminBaseController
    {
        private AccountService accountService = new AccountService();

        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            List<AppUser> appUsers = accountService.GetAll();
            return View(appUsers);
        }

        // GET: Admin/Account/Create
        public ActionResult Create()
        {
            ViewData["CurrentMenu"] = "system";
            return View();
        }

        // GET: Admin/Account/Detail/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "system";
            AppUser user = accountService.GetByPrimaryKey(id);
            return View(user);
        }

        // GET: Admin/Account/Delete/1
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}