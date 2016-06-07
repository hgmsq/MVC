using MVCDemo.DAL;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    public class AccountInitializer:DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser {UserName="admin",PassWord="admin",Email="admin@qq.com" },
                new SysUser {UserName="guest",PassWord="guest",Email="admin@qq.com"}
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();

            var sysRoles = new List<SysRole>
            {
                new SysRole {RoleName="Administrator",RoleDesc="管理员" },
                new SysRole {RoleName="Guest",RoleDesc="访客" }
            };
            sysRoles.ForEach(s => context.SysRoles.Add(s));
            context.SaveChanges();

            var sysUserRole = new List<SysUserRole>
            {
                new SysUserRole {SysUserID=1,SysRoleID=1 },
                new SysUserRole {SysUserID=2,SysRoleID=2 }
            };
            sysUserRole.ForEach(s => context.SysUserRoles.Add(s));
            context.SaveChanges();
        }
    }
}