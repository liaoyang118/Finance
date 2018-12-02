 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.Finance.DataAccess.Model;
using Site.Finance.DataAccess.Access;

namespace Site.Finance.DataAccess.Service
{

	public partial class PersonBillService
    {

        #region 01 PersonBill_Insert
		 public static int Insert(PersonBill obj)
		 {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.Insert(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 PersonBill_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.Delete(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 PersonBill_Update
		 public static int Update(PersonBill obj)
		 {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.Update(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 PersonBill_SelectObject
		 public static PersonBill SelectObject(int id)
		 {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.SelectObject(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 PersonBill_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<PersonBill> Select(string whereStr)
		 {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.Select(whereStr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 PersonBill_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<PersonBill> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new PersonBillAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 PersonBill_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<PersonBill> list,int count)
        {
			try
			{
				using (var access = new PersonBillAccess())
				{
					return access.SqlBulkCopyBatchInsert(list, count);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class UsersService
    {

        #region 01 Users_Insert
		 public static int Insert(Users obj)
		 {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.Insert(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 Users_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.Delete(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Users_Update
		 public static int Update(Users obj)
		 {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.Update(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Users_SelectObject
		 public static Users SelectObject(int id)
		 {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.SelectObject(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Users_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Users> Select(string whereStr)
		 {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.Select(whereStr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 Users_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<Users> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new UsersAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Users_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<Users> list,int count)
        {
			try
			{
				using (var access = new UsersAccess())
				{
					return access.SqlBulkCopyBatchInsert(list, count);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
}
