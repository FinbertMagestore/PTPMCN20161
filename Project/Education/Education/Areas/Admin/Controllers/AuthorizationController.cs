using Microsoft.AspNet.Identity;
using Education.Areas.Admin.Model;
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
    public class AuthorizationController : AdminBaseController
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            try
            {
                HttpCookie cookieAspx = Request.Cookies[".ASPXAUTH"];
                HttpCookie roleUser = Request.Cookies["_role"];
                if (cookieAspx != null)
                {
                    if (roleUser != null)
                    {
                        string roles = roleUser.Values["_roleUser"];
                        if (!string.IsNullOrEmpty(roles) && roles.Contains("Admin"))
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
                        else
                        {
                            if (!string.IsNullOrEmpty(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home", new { area = "Client" });
                            }
                        }
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
                                String[] roleUsers = Roles.GetRolesForUser(userName);
                                string roles = GetRolesOfUser(roleUsers);
                                HttpCookie cookie = Request.Cookies["_role"];
                                if (cookie == null)
                                {
                                    cookie = new HttpCookie("_role");
                                }
                                cookie.Values.Add("_roleUser", roles);
                                cookie.Expires = DateTime.Now.AddMinutes(960);
                                Response.Cookies.Add(cookie);
                                FormsAuthentication.SetAuthCookie(userName, model.RememberMe);
                                if (Roles.IsUserInRole(userName, "Admin"))
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
                                else if (Roles.IsUserInRole(userName, "Client"))
                                {
                                    if (!string.IsNullOrEmpty(ReturnUrl))
                                    {
                                        return Redirect(ReturnUrl);
                                    }
                                    else
                                    {
                                        return RedirectToAction("Index", "Home", new { area = "Client" });
                                    }
                                }
                            }
                            else
                            {
                                ViewBag.Fail = "Tài khoản hoặc mật khẩu không đúng.";
                                //ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                            }
                        }
                        else
                        {
                            ViewBag.Fail = "Tài khoản hoặc mật khẩu không tồn tại.";
                            //ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không tồn tại.");
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

        private static string GetRolesOfUser(string[] roleUsers)
        {
            string roles = "";
            if (roleUsers != null && roleUsers.Length > 0)
            {
                for (int i = 0; i < roleUsers.Length; i++)
                {
                    if (i != roleUsers.Length - 1)
                    {
                        roles += roleUsers[i] + ",";
                    }
                    else
                    {
                        roles += roleUsers[i];
                    }
                }
            }
            return roles;
        }
    }
}