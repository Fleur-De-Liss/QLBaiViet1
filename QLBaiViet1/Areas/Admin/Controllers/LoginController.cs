using Models;
using QLBaiViet1.Areas.Admin.Models;
using QLBaiViet1.Areas.Admin.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLBaiViet1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {
            if (Membership.ValidateUser(loginModel.Username, loginModel.Password) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(loginModel.Username, loginModel.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }
            return View(loginModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}