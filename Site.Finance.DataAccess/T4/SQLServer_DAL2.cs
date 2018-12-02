

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using System.Configuration;
using Site.Finance.DataAccess.Model;

namespace Site.Finance.DataAccess.Access
{


	[Serializable]
	public partial class PersonBillAccess : AccessBase<PersonBill>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public PersonBillAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings["PersonFinance"].ToString();
        }

        public PersonBillAccess()
        {
            db = factory.Create("PersonFinance");
			DataTableName = "PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings["PersonFinance"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~PersonBillAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_PersonBill_Insert
		 public override int Insert(PersonBill obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@u_id", DbType.Int32,obj.u_id);
			db.AddInParameter(dbCmd, "@io_flag", DbType.Int32,obj.io_flag);
			db.AddInParameter(dbCmd, "@total_money", DbType.Decimal,obj.total_money);
			db.AddInParameter(dbCmd, "@item_name", DbType.String,obj.item_name);
			db.AddInParameter(dbCmd, "@item_money", DbType.Decimal,obj.item_money);
			db.AddInParameter(dbCmd, "@money_type", DbType.Int32,obj.money_type);
			db.AddInParameter(dbCmd, "@create_time", DbType.DateTime,obj.create_time);
			db.AddInParameter(dbCmd, "@remark", DbType.String,obj.remark);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_PersonBill_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_PersonBill_Update
		 public override int Update(PersonBill obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@u_id", DbType.Int32,obj.u_id);
			db.AddInParameter(dbCmd, "@io_flag", DbType.Int32,obj.io_flag);
			db.AddInParameter(dbCmd, "@total_money", DbType.Decimal,obj.total_money);
			db.AddInParameter(dbCmd, "@item_name", DbType.String,obj.item_name);
			db.AddInParameter(dbCmd, "@item_money", DbType.Decimal,obj.item_money);
			db.AddInParameter(dbCmd, "@money_type", DbType.Int32,obj.money_type);
			db.AddInParameter(dbCmd, "@create_time", DbType.DateTime,obj.create_time);
			db.AddInParameter(dbCmd, "@remark", DbType.String,obj.remark);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_PersonBill_SelectObject
		 public override PersonBill SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			PersonBill obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_PersonBill_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<PersonBill> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<PersonBill> list= new List<PersonBill>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						PersonBill obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_PersonBill_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<PersonBill> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_PersonBill_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<PersonBill> list= new List<PersonBill>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						PersonBill obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public PersonBill Object2Model(IDataReader reader)
        {
            PersonBill obj = null;
            try
            {
                obj = new PersonBill();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.u_id = reader["u_id"] == DBNull.Value ? default(int) : (int)reader["u_id"];
				obj.io_flag = reader["io_flag"] == DBNull.Value ? default(int) : (int)reader["io_flag"];
				obj.total_money = reader["total_money"] == DBNull.Value ? default(decimal) : (decimal)reader["total_money"];
				obj.item_name = reader["item_name"] == DBNull.Value ? default(string) : (string)reader["item_name"];
				obj.item_money = reader["item_money"] == DBNull.Value ? default(decimal) : (decimal)reader["item_money"];
				obj.money_type = reader["money_type"] == DBNull.Value ? default(int) : (int)reader["money_type"];
				obj.create_time = reader["create_time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["create_time"];
				obj.remark = reader["remark"] == DBNull.Value ? default(string) : (string)reader["remark"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class UsersAccess : AccessBase<Users>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public UsersAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings["PersonFinance"].ToString();
        }

        public UsersAccess()
        {
            db = factory.Create("PersonFinance");
			DataTableName = "Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings["PersonFinance"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~UsersAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Users_Insert
		 public override int Insert(Users obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_Users_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_Users_Update
		 public override int Update(Users obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@Account", DbType.String,obj.Account);
			db.AddInParameter(dbCmd, "@Password", DbType.String,obj.Password);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_Users_SelectObject
		 public override Users SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Users obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_Users_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<Users> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<Users> list= new List<Users>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Users obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_Users_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<Users> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Users_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<Users> list= new List<Users>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Users obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public Users Object2Model(IDataReader reader)
        {
            Users obj = null;
            try
            {
                obj = new Users();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Account = reader["Account"] == DBNull.Value ? default(string) : (string)reader["Account"];
				obj.Password = reader["Password"] == DBNull.Value ? default(string) : (string)reader["Password"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
}
