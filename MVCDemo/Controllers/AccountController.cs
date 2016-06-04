using MVCDemo.DAL;
using MVCDemo.Models;
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
            return View(db.SysUsers);
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
        public ActionResult EFUpdateDemo()
        {
            //1.找到对象
            var sysUser = db.SysUsers.FirstOrDefault(u => u.UserName == "admin");
            //2.更新对象数据
            if (sysUser!=null)
            {
                sysUser.UserName = "admin2";
            }
            //保存修改
            db.SaveChanges();
            return View();
        }
        public ActionResult EFAddDemo()
        {
            //1. 创建新的实体
            var newSysUser = new SysUser()
            {
                UserName = "Jordan",
                PassWord = "123",
                Email = "Jordan@163.com"
            };
            //2. 增加
            db.SysUsers.Add(newSysUser);
            //3. 保存修改
            db.SaveChanges();
            return View("EFQueryDemo");
        }
        public ActionResult EFDeleteDemo()
        {
            //1. 找到需要删除的对象
            var delSysUser = db.SysUsers.FirstOrDefault(u => u.UserName == "Jordan");
            //2. 删除
            if (delSysUser!=null)
            {
                db.SysUsers.Remove(delSysUser);
            }
            //3. 保存修改
            db.SaveChanges();
            return View("EFQueryDemo");
        }
        public ActionResult Details(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }
    }
}