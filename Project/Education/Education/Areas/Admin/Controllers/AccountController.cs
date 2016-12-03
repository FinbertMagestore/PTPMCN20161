using Education.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Education.Areas.Admin.Services;
using Microsoft.AspNet.Identity;
using Education.Areas.Admin.Utilz;

namespace Education.Areas.Admin.Controllers
{
    // User: Huy
    // TODO: CRUD người dùng

    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        private IDbConnection connect = new SqlConnection(Common.ConnectString);

        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Account/Detail/1
        public ActionResult Detail(int id)
        {
            return View();
        }

        // old
        // GET: Admin/Account/Edit/1
        public ActionResult Edit(int id)
        {
            try
            {
                AppUser user = accountService.GetByPrimaryKey(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return RedirectToAction("Index", "Dashboard");
            }

        }

        // GET: Admin/Account/Delete/1
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}