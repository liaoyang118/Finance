using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Common
{
    public class UntityTool
    {
        public static string GetConfigValue(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                result = "";
            }

            return result;
        }

        public static string Md5_32(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }

        public static int GetTimeSpan()
        {
            //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds * 1000);

            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (int)(DateTime.Now - startTime).TotalSeconds;
            return intResult;
        }

        public static DateTime TimespanToDatetime(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timeStamp);
            return dt;
        }

        public static string CreateListPage(int interval, int pageSize, int pageIndex, int rowCount, string urlBase)
        {
            /*
             <ul class="pagination pagination-lg">
                    <li><a href="#">上一页</a></li>
                    <li class="active"><a href="#">1</a></li>
                    <li class="disabled"><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#">下一页</a></li>
                </ul>
            */
            string result = string.Empty;

            string pageHtml = "<ul class=\"pagination pagination-lg\">{0}</ul>";
            string a_url = string.Empty;
            int totalPage = (int)Math.Ceiling(rowCount * 1.00 / pageSize * 1.00);
            if (totalPage > 1)
            {
                if (pageIndex != 1)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">首页</a></li>\r\n", GetListUrl(1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">上一页</a></li>\r\n", GetListUrl(pageIndex - 1, urlBase));
                }
                //页码条中间的间隔
                int barInteval = interval;
                int defaulStart = 1, defaultEnd = barInteval;
                //生成页码条的 起始位置---间隔页位置
                if (pageIndex % barInteval == 0)
                {
                    defaulStart = pageIndex - barInteval + 1;
                    defaultEnd = pageIndex + barInteval;

                    if (defaultEnd > totalPage)
                    {
                        defaultEnd = totalPage;
                    }
                }
                //首页时
                else if (pageIndex == 1)
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex;
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }
                //尾页时
                else if (pageIndex == totalPage)
                {

                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        defaultEnd = totalPage;
                    }
                    else
                    {
                        defaulStart = 1;
                        defaultEnd = totalPage;
                    }
                }

                //中间页时
                else
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        if (defaulStart < 0)
                        {
                            defaulStart = 1;
                        }
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }


                //生成中间的页码条
                for (int i = defaulStart; i <= defaultEnd; i++)
                {
                    a_url += string.Format("<li class=\"{2}\"><a href=\"{0}\">{1}</a></li>\r\n", GetListUrl(i, urlBase), i, i == pageIndex ? "active" : "");
                }

                if (pageIndex != totalPage)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">下一页</a></li>\r\n", GetListUrl(pageIndex + 1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">尾页</a></li>\r\n", GetListUrl(totalPage, urlBase));
                }

                result = string.Format(pageHtml, a_url);
            }

            return result;
        }


        private static string GetListUrl(int current, string url)
        {
            string result = string.Empty;
            if (url.Contains("?"))
            {
                result = url + "&page=" + current;
            }
            else
            {
                result = url + "?page=" + current;
            }

            return result;
        }
    }
}
