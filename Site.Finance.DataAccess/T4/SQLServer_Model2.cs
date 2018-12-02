

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Finance.DataAccess.Model
{

	[Serializable]
	public partial class PersonBill
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region u_id
		private int _u_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int u_id 
		{ 
			get { return _u_id; } 
			set { _u_id = value; } 
		
		}
		#endregion
		
		#region io_flag
		private int _io_flag;
       
        /// <summary>
        /// 
        /// </summary>        
        public int io_flag 
		{ 
			get { return _io_flag; } 
			set { _io_flag = value; } 
		
		}
		#endregion
		
		#region total_money
		private decimal _total_money;
       
        /// <summary>
        /// 
        /// </summary>        
        public decimal total_money 
		{ 
			get { return _total_money; } 
			set { _total_money = value; } 
		
		}
		#endregion
		
		#region item_name
		private string _item_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string item_name 
		{ 
			get { return _item_name; } 
			set { _item_name = value; } 
		
		}
		#endregion
		
		#region item_money
		private decimal _item_money;
       
        /// <summary>
        /// 
        /// </summary>        
        public decimal item_money 
		{ 
			get { return _item_money; } 
			set { _item_money = value; } 
		
		}
		#endregion
		
		#region money_type
		private int _money_type;
       
        /// <summary>
        /// 
        /// </summary>        
        public int money_type 
		{ 
			get { return _money_type; } 
			set { _money_type = value; } 
		
		}
		#endregion
		
		#region create_time
		private DateTime _create_time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime create_time 
		{ 
			get { return _create_time; } 
			set { _create_time = value; } 
		
		}
		#endregion
		
		#region remark
		private string _remark;
       
        /// <summary>
        /// 
        /// </summary>        
        public string remark 
		{ 
			get { return _remark; } 
			set { _remark = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Users
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region Account
		private string _Account;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Account 
		{ 
			get { return _Account; } 
			set { _Account = value; } 
		
		}
		#endregion
		
		#region Password
		private string _Password;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Password 
		{ 
			get { return _Password; } 
			set { _Password = value; } 
		
		}
		#endregion
		
    }
	
}