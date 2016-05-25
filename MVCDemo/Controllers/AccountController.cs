using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        private AccountContext db = new AccountContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前......";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail"];
            string password = fc["inputPassword"];
            var user = db.SysUsers.Where(b => b.Email == email & b.PassWord == password);
            if (user.Count() > 0)
            {
                ViewBag.LoginState = email + "登陆后......";
            }
            else
            {
                ViewBag.LoginState = email + "用户不存在......";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

    }
}