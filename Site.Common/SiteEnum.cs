using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Common
{
    public class SiteEnum
    {
        /// <summary>
        /// 账单类型
        /// </summary>
        public enum MoneyType
        {
            总额 = 1,
            总额扣减项 = 2,
            当月支出项 = 3
        }
    }
}
