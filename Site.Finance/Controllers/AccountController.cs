using Site.Common;
using Site.Finance.DataAccess.Model;
using Site.Finance.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Site.Finance.Tool;

namespace Site.Finance.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost, AllowAnonymous]
        public ActionResult Login(Users users)
        {
            Users uInfo = UsersService.Select(string.Format(" where Account='{0}'", users.Account)).FirstOrDefault();
            if (uInfo != null)
            {
                if (UntityTool.Md5_32(users.Password) == uInfo.Password)
                {



                    //保存用户
                    HttpContextUntity.CurrentUser = uInfo;
                    string remenber = Request["remenber"] ?? string.Empty;

                    #region ticket 方法

                    //创建一个新的票据，将客户ip记入ticket的userdata 
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, users.Account, DateTime.Now, DateTime.Now.AddHours(2), false, uInfo.Id.ToString());
                    //将票据加密 
                    string authTicket = FormsAuthentication.Encrypt(ticket);
                    //将加密后的票据保存为cookie 
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                    if (!string.IsNullOrEmpty(remenber))
                    {
                        cookie.Expires = DateTime.Now.AddDays(1);
                    }

                    Response.Cookies.Add(cookie);

                    #endregion

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("503", "密码错误！");
                }
            }
            else
            {
                ModelState.AddModelError("404", "账号错误！");
            }



            return View();
        }


        public void LoginOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}