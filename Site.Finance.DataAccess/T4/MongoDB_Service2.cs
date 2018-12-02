 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using MongoDB.Driver;
using Site.Finance.DataAccess.Model;
using Site.Finance.DataAccess.Access;

namespace Site.Finance.DataAccess.Service
{

	public partial class Mongo_PersonBillService
    {

        #region 01 Mongo_PersonBill_Insert
		 public static string Insert(Mongo_PersonBill obj)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
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
		
		#region 02 Mongo_PersonBill_Delete
		 public static int Delete(Expression<Func<Mongo_PersonBill,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.Delete(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_PersonBill_Update
		 public static int Update(Expression<Func<Mongo_PersonBill, bool>> filter,Mongo_PersonBill obj)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.Update(filter,obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_PersonBill_SelectObject
		 public static Mongo_PersonBill SelectObject(Expression<Func<Mongo_PersonBill, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.SelectObject(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_PersonBill_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_PersonBill> Select(Expression<Func<Mongo_PersonBill, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.Select(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_PersonBill_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_PersonBill> Select(Expression<Func<Mongo_PersonBill, bool>> filter,SortDefinition<Mongo_PersonBill> order)
		 {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.Select(filter,order);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_PersonBill_SelectPage
		 public static IList<Mongo_PersonBill> SelectPage(SortDefinition<Mongo_PersonBill> order, Expression<Func<Mongo_PersonBill, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_PersonBillAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_PersonBill_BatchInsert
        public static void BatchInsert(IList<Mongo_PersonBill> list)
        {
			try
			{
				using (var access = new Mongo_PersonBillAccess())
				{
					access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class Mongo_UsersService
    {

        #region 01 Mongo_Users_Insert
		 public static string Insert(Mongo_Users obj)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
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
		
		#region 02 Mongo_Users_Delete
		 public static int Delete(Expression<Func<Mongo_Users,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					return access.Delete(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_Users_Update
		 public static int Update(Expression<Func<Mongo_Users, bool>> filter,Mongo_Users obj)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					return access.Update(filter,obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_Users_SelectObject
		 public static Mongo_Users SelectObject(Expression<Func<Mongo_Users, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					return access.SelectObject(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_Users_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Users> Select(Expression<Func<Mongo_Users, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					return access.Select(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_Users_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Users> Select(Expression<Func<Mongo_Users, bool>> filter,SortDefinition<Mongo_Users> order)
		 {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					return access.Select(filter,order);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_Users_SelectPage
		 public static IList<Mongo_Users> SelectPage(SortDefinition<Mongo_Users> order, Expression<Func<Mongo_Users, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_UsersAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_Users_BatchInsert
        public static void BatchInsert(IList<Mongo_Users> list)
        {
			try
			{
				using (var access = new Mongo_UsersAccess())
				{
					access.BatchInsert(list);
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
