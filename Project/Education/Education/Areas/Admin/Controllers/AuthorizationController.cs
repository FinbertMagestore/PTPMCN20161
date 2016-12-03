using Microsoft.AspNet.Identity;
using Education.Areas.Admin.Models;
using Education.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Areas.Admin.Controllers
{
    public class AuthorizationController : Controller
    {
        private IDbConnection connect = new SqlConnection(Common.ConnectString);
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            try
            {
                HttpCookie myCookie = Request.Cookies[".ASPXAUTH"];

                if (myCookie != null)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Fail = "Không thể kết nối tới server";
                return View();
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LogOnModel model, string ReturnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        string userName = Membership.GetUserNameByEmail(model.Email);
                        if (!string.IsNullOrEmpty(userName))
                        {
                            if (Membership.ValidateUser(userName, model.Password))
                            {
                                if (Roles.IsUserInRole(userName, "Admin"))
                                {
                                    FormsAuthentication.SetAuthCookie(userName, model.RememberMe);
                                    if (!string.IsNullOrEmpty(ReturnUrl))
                                    {
                                        return Redirect(ReturnUrl);
                                    }
                                    else
                                    {
                                        return RedirectToAction("Index", "Dashboard");
                                    }
                                }
                                else
                                {
                                    ViewBag.Fail = "Tài khoản hoặc mật khẩu không có quyền admin.";
                                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không có quyền admin.");
                                }
                            }
                            else
                            {
                                ViewBag.Fail = "Tài khoản hoặc mật khẩu không đúng.";
                                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                            }
                        }
                        else
                        {
                            ViewBag.Fail = "Tài khoản hoặc mật khẩu không tồn tại.";
                            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không tồn tại.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Fail = "Không thể kết nối tới server";
                LogService.WriteException(ex);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authorization");
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Authorization");
        }
    }
}