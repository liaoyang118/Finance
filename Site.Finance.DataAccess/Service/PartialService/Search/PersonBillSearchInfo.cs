using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Finance.DataAccess.Service.PartialService.Search
{
    public class PersonBillSearchInfo
    {
        public string OrderBy = "create_time desc";


        public int? u_id { get; set; }
        public List<int> money_type { get; set; }


        public string begin { get; set; }
        public string end { get; set; }



        public string ToWhereString()
        {
            List<string> where = new List<string>();

            if (u_id != null)
            {
                where.Add(string.Format("u_id={0}", u_id));
            }

            if (money_type != null)
            {
                where.Add(string.Format("money_type in ({0})", string.Join(",", money_type)));
            }

            if (string.IsNullOrEmpty(begin))
            {
                where.Add(string.Format("create_time >= '{0}'", begin));
            }

            if (string.IsNullOrEmpty(end))
            {
                where.Add(string.Format("create_time <= '{0}'", end));
            }

            if (where.Count > 0)
            {
                return string.Format(" where {0}", string.Join(" and ", where.ToList()));
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
