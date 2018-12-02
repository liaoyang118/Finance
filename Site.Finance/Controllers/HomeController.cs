using Site.Common;
using Site.Finance.DataAccess.Model;
using Site.Finance.DataAccess.Service;
using Site.Finance.DataAccess.Service.PartialService.Search;
using System.Collections.Generic;
using System.Web.Mvc;
using Site.Finance.Tool;
using System;

namespace Site.Finance.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            DateTime now = DateTime.Now;
            DateTime begin = new DateTime(now.Year, now.Month, 1);
            DateTime end = begin.AddMonths(1).AddDays(-1);

            PersonBillSearchInfo search = new PersonBillSearchInfo();
            search.u_id = HttpContextUntity.CurrentUser.Id;
            search.money_type = new List<int>() { (int)SiteEnum.MoneyType.总额, (int)SiteEnum.MoneyType.总额扣减项 };
            search.begin = begin.ToString("yyyy-MM-dd ") + "00:00:01";
            search.end = end.ToString("yyyy-MM-dd ") + "23:59:59";


            IList<PersonBill> list = PersonBillService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.u_id = HttpContextUntity.CurrentUser.Id;


            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;


            return View();
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PersonBill bill)
        {
            if (bill != null)
            {
                bill.u_id = HttpContextUntity.CurrentUser.Id;
                bill.io_flag = bill.money_type == (int)SiteEnum.MoneyType.总额 ? 1 : -1;
                bill.item_money = bill.item_money * bill.io_flag;
                bill.create_time = DateTime.Now;

                int result = PersonBillService.Insert(bill);

                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("500", "信息错误，请稍后再试！");
                }

            }
            else
            {
                ModelState.AddModelError("500", "信息错误，请稍后再试！");
            }

            return View();
        }


        public ActionResult MonthBill(int? page)
        {
            int pageSize = 10;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            DateTime now = DateTime.Now;
            DateTime begin = new DateTime(now.Year, now.Month, 1);
            DateTime end = begin.AddMonths(1).AddDays(-1);

            PersonBillSearchInfo search = new PersonBillSearchInfo();
            search.u_id = HttpContextUntity.CurrentUser.Id;
            search.money_type = new List<int>() { (int)SiteEnum.MoneyType.当月支出项 };
            search.begin = begin.ToString("yyyy-MM-dd ") + "00:00:01";
            search.end = end.ToString("yyyy-MM-dd ") + "23:59:59";


            IList<PersonBill> list = PersonBillService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.u_id = HttpContextUntity.CurrentUser.Id;


            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;


            return View();
        }


        [HttpGet]
        public ActionResult AddMonthBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMonthBill(PersonBill bill)
        {
            if (bill != null)
            {
                bill.u_id = HttpContextUntity.CurrentUser.Id;
                bill.io_flag = bill.money_type;
                bill.money_type = (int)SiteEnum.MoneyType.当月支出项;

                //收入
                bill.total_money = bill.total_money * bill.io_flag;

                //支出
                bill.item_money = bill.total_money * bill.io_flag;

                if (bill.io_flag > 0)
                {
                    bill.item_money = 0;
                }
                else
                {
                    bill.total_money = 0;
                }

                bill.create_time = DateTime.Now;

                int result = PersonBillService.Insert(bill);

                if (result > 0)
                {
                    return RedirectToAction("MonthBill", "Home");
                }
                else
                {
                    ModelState.AddModelError("500", "信息错误，请稍后再试！");
                }

            }
            else
            {
                ModelState.AddModelError("500", "信息错误，请稍后再试！");
            }

            return View();
        }

    }
}