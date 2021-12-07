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
            var res = new AccountModel().Login(loginModel.Username, loginModel.Password);
            if (res && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { Username = loginModel.Username });
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