using Education.Areas.Admin.Model;
using Education.Areas.Admin.Services;
using Education.Areas.Admin.Utilz;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Areas.Admin.Controllers
{
    // User: Huy
    // TODO: CRUD người dùng

    [Authorize(Roles = "Admin")]
    public class AccountController : AdminBaseController
    {
        private AccountService accountService = new AccountService();
        private RoleService roleService = new RoleService();
        private TeacherService teacherService = new TeacherService();
        private LessionnService lessionnService = new LessionnService();
        private StudentService studentService = new StudentService();
        private PostService postService = new PostService();

        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            List<AppUser> appUsers = accountService.GetAll();
            if (appUsers != null && appUsers.Count > 0)
            {
                foreach (var item in appUsers)
                {
                    UpdateModel(item);
                }
            }
            return View(appUsers);
        }

        // GET: Admin/Account/Create
        public ActionResult Create()
        {
            ViewData["CurrentMenu"] = "system";
            AppUser appUser = new AppUser();
            UpdateModel(appUser);
            return View(appUser);
        }

        [HttpPost]
        public ActionResult Create(AppUser appUser)
        {
            ViewData["CurrentMenu"] = "system";
            UpdateModel(appUser);

            AppUser appUserByUserName = accountService.GetUserByUsername(appUser.Username);
            AppUser appUserByEmail = accountService.GetUserByemail(appUser.Email);
            bool errorFlag = false;
            if (string.IsNullOrEmpty(appUser.Password))
            {
                ModelState.AddModelError("Password", "Mật khẩu không được để trống");
                errorFlag = true;
            }
            if (appUserByUserName != null)
            {
                ModelState.AddModelError("Username", "Username đã được sử dụng");
                errorFlag = true;
            }
            if (appUserByEmail != null)
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng");
                errorFlag = true;
            }
            if (!errorFlag)
            {
                appUser.DateCreated = DateTime.Now;
                appUser.LastActivityDate = DateTime.Now;
                appUser.Modified = DateTime.Now;
                appUser.Birthday = null;
                appUser.Sex = null;
                appUser.IsActive = true;
                appUser.Password = Encryption.GetMD5Hash(appUser.Password);
                int userID = accountService.Insert(appUser);
                if (userID > 0)
                {
                    appUser.Id = userID;
                    if (appUser.RoleID > 0)
                    {
                        if (appUser.RoleID != (int)Config.Roles.Client
                            && (appUser.RoleID == (int)Config.Roles.Student || appUser.RoleID == (int)Config.Roles.Teacher))
                        {
                            roleService.InsertUserRole(new AspNetUserRole { UserId = userID, RoleId = (int)Config.Roles.Client });
                        }
                        roleService.InsertUserRole(new AspNetUserRole { UserId = userID, RoleId = appUser.RoleID });
                    }
                }

                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        // GET: Admin/Account/Detail/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "system";
            AppUser appUser = accountService.GetByPrimaryKey(id);
            UpdateModel(appUser);
            return View(appUser);
        }

        [HttpPost]
        public ActionResult Edit(AppUser appUser)
        {
            ViewData["CurrentMenu"] = "system";
            UpdateModel(appUser);

            AppUser appUserByUserName = accountService.GetUserByUsername(appUser.Username);
            AppUser appUserByEmail = accountService.GetUserByemail(appUser.Email);
            bool errorFlag = false;
            if (appUserByUserName != null && appUserByUserName.Id != appUser.Id)
            {
                ModelState.AddModelError("Username", "Username đã được sử dụng");
                errorFlag = true;
            }
            if (appUserByEmail != null && appUserByEmail.Id != appUser.Id)
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng");
                errorFlag = true;
            }
            if (!errorFlag)
            {
                bool needExit = false;
                if (appUser.Id == (int)Membership.GetUser(User.Identity.GetUserName()).ProviderUserKey)
                {
                    needExit = true;
                }
                appUser.Modified = DateTime.Now;
                appUser.Password = Encryption.GetMD5Hash(appUser.Password);

                //delete all role exist and add new
                roleService.DeleteAllRoleOfUser(appUser.Id);
                if (appUser.RoleID != (int)Config.Roles.Client
                    && (appUser.RoleID == (int)Config.Roles.Student || appUser.RoleID == (int)Config.Roles.Teacher))
                {
                    roleService.InsertUserRole(new AspNetUserRole { UserId = appUser.Id, RoleId = (int)Config.Roles.Client });
                }
                roleService.InsertUserRole(new AspNetUserRole { UserId = appUser.Id, RoleId = appUser.RoleID });

                accountService.Update(appUser);
                if (needExit)
                {
                    return RedirectToAction("Logout", "Authorization");
                }

                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        // GET: Admin/Account/Delete/1
        public ActionResult Delete(int id)
        {
            ViewData["CurrentMenu"] = "system";
            AppUser appUser = accountService.GetByPrimaryKey(id);
            UpdateModel(appUser);
            bool canDelete = true;
            List<Post> posts = postService.GetByUserID(appUser.Id);
            if (posts != null && posts.Count > 0)
            {
                canDelete = false;
            }
            if (canDelete)
            {
                if (appUser.RoleID == (int)Config.Roles.Teacher)
                {
                    Teacher teacher = teacherService.GetByUserID(appUser.Id);
                    if (teacher != null)
                    {
                        List<Lession> lessions = lessionnService.GetByTeacherID(teacher.ID);
                        if (lessions != null && lessions.Count > 0)
                        {
                            canDelete = false;
                        }
                    }
                }
            }
            appUser.CanDelete = canDelete;
            return View(appUser);
        }
        [HttpPost]
        public ActionResult Delete(AppUser appUser)
        {
            UpdateModel(appUser);
            AspNetRole role = roleService.GetRoleOfUser(appUser.Id);
            if (role != null)
            {
                if (role.Id == (int)Config.Roles.Student)
                {
                    studentService.DeleteByUserID(appUser.Id);
                }
                else if (role.Id == (int)Config.Roles.Teacher)
                {
                    teacherService.DeleteByUserID(appUser.Id);
                }
                roleService.DeleteAllRoleOfUser(appUser.Id);
                accountService.DeleteByPrimaryKey(appUser.Id);
                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        private void UpdateModel(AppUser appUser)
        {
            try
            {
                appUser.Roles = roleService.GetAllRole();
                appUser.Role = accountService.GetRolesOfUser(appUser);
                if (appUser.Id > 0)
                {
                    AspNetRole role = roleService.GetRoleOfUser(appUser.Id);
                    appUser.RoleID = role.Id;
                }
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
            }
        }
    }
}