using Site.Finance.DataAccess.Model;
using Site.Finance.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Finance.Tool
{
    public class HttpContextUntity
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static Users CurrentUser
        {
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    return (Users)HttpContext.Current.Session["user"];
                }
                else
                {
                    string name = HttpContext.Current.User.Identity.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        Users uInfo = UsersService.Select(string.Format(" where Account='{0}'", name)).FirstOrDefault();
                        return uInfo;
                    }
                    return null;
                }
            }
        }
    }
}