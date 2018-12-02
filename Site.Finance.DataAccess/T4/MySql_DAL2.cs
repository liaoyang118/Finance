

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using System.Configuration;
using Site.Finance.DataAccess.Model;

namespace Site.Finance.DataAccess.Access
{


	[Serializable]
	public partial class MySql_PersonBillAccess : MySql_AccessBase<PersonBill>,IDisposable
    {

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
        public MySql_PersonBillAccess(string configName)
        {
			GetCommand();
			DataTableName = "PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
        }

        public MySql_PersonBillAccess()
        {
            GetCommand();
			DataTableName = "PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_PersonFinance"].ToString();
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
        ~MySql_PersonBillAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_PersonBill_Insert
		 public override int Insert(PersonBill obj)
		 {
			try
			{ 
				Command.CommandText="Proc_PersonBill_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.Int32));
				Command.Parameters["@u_id"].Value=obj.u_id;					
				Command.Parameters.Add(new MySqlParameter("@io_flag", MySqlDbType.Int32));
				Command.Parameters["@io_flag"].Value=obj.io_flag;					
				Command.Parameters.Add(new MySqlParameter("@total_money", MySqlDbType.Decimal));
				Command.Parameters["@total_money"].Value=obj.total_money;					
				Command.Parameters.Add(new MySqlParameter("@item_name", MySqlDbType.String));
				Command.Parameters["@item_name"].Value=obj.item_name;					
				Command.Parameters.Add(new MySqlParameter("@item_money", MySqlDbType.Decimal));
				Command.Parameters["@item_money"].Value=obj.item_money;					
				Command.Parameters.Add(new MySqlParameter("@money_type", MySqlDbType.Int32));
				Command.Parameters["@money_type"].Value=obj.money_type;					
				Command.Parameters.Add(new MySqlParameter("@create_time", MySqlDbType.DateTime));
				Command.Parameters["@create_time"].Value=obj.create_time;					
				Command.Parameters.Add(new MySqlParameter("@remark", MySqlDbType.String));
				Command.Parameters["@remark"].Value=obj.remark;					
							
				int returnValue = Command.ExecuteNonQuery();
				int Id = (int)Command.Parameters["@Id"].Value;
				DisposeCommand();
                DisposeConnection();
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_PersonBill_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_PersonBill_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_PersonBill_Update
		 public override int Update(PersonBill obj)
		 {
			try
			{ 
			Command.CommandText="Proc_PersonBill_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.Int32));
				Command.Parameters["@u_id"].Value=obj.u_id;	
				Command.Parameters.Add(new MySqlParameter("@io_flag", MySqlDbType.Int32));
				Command.Parameters["@io_flag"].Value=obj.io_flag;	
				Command.Parameters.Add(new MySqlParameter("@total_money", MySqlDbType.Decimal));
				Command.Parameters["@total_money"].Value=obj.total_money;	
				Command.Parameters.Add(new MySqlParameter("@item_name", MySqlDbType.String));
				Command.Parameters["@item_name"].Value=obj.item_name;	
				Command.Parameters.Add(new MySqlParameter("@item_money", MySqlDbType.Decimal));
				Command.Parameters["@item_money"].Value=obj.item_money;	
				Command.Parameters.Add(new MySqlParameter("@money_type", MySqlDbType.Int32));
				Command.Parameters["@money_type"].Value=obj.money_type;	
				Command.Parameters.Add(new MySqlParameter("@create_time", MySqlDbType.DateTime));
				Command.Parameters["@create_time"].Value=obj.create_time;	
				Command.Parameters.Add(new MySqlParameter("@remark", MySqlDbType.String));
				Command.Parameters["@remark"].Value=obj.remark;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_PersonBill_SelectObject
		 public override PersonBill SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_PersonBill_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			PersonBill obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
			Command.CommandText="Proc_PersonBill_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<PersonBill> list= new List<PersonBill>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						PersonBill obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
			Command.CommandText="Proc_PersonBill_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<PersonBill> list= new List<PersonBill>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						PersonBill obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__PersonBill_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<PersonBill> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append("DataTableName");
				sb.Append(" (");

				sb.Append("u_id");	
				sb.Append(",");		
				sb.Append("io_flag");	
				sb.Append(",");		
				sb.Append("total_money");	
				sb.Append(",");		
				sb.Append("item_name");	
				sb.Append(",");		
				sb.Append("item_money");	
				sb.Append(",");		
				sb.Append("money_type");	
				sb.Append(",");		
				sb.Append("create_time");	
				sb.Append(",");		
				sb.Append("remark");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(PersonBill item in list)
				{
				sb.Append("(");
								sb.Append(item.u_id);
									sb.Append(",");
										sb.Append(item.io_flag);
									sb.Append(",");
										sb.Append(item.total_money);
									sb.Append(",");
										sb.Append("\""+item.item_name+"\"");
									sb.Append(",");
										sb.Append(item.item_money);
									sb.Append(",");
										sb.Append(item.money_type);
									sb.Append(",");
										sb.Append("\""+item.create_time.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.remark+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
	public partial class MySql_UsersAccess : MySql_AccessBase<Users>,IDisposable
    {

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
        public MySql_UsersAccess(string configName)
        {
			GetCommand();
			DataTableName = "Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
        }

        public MySql_UsersAccess()
        {
            GetCommand();
			DataTableName = "Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_PersonFinance"].ToString();
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
        ~MySql_UsersAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Users_Insert
		 public override int Insert(Users obj)
		 {
			try
			{ 
				Command.CommandText="Proc_Users_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@Account", MySqlDbType.String));
				Command.Parameters["@Account"].Value=obj.Account;					
				Command.Parameters.Add(new MySqlParameter("@Password", MySqlDbType.String));
				Command.Parameters["@Password"].Value=obj.Password;					
							
				int returnValue = Command.ExecuteNonQuery();
				int Id = (int)Command.Parameters["@Id"].Value;
				DisposeCommand();
                DisposeConnection();
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_Users_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_Users_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_Users_Update
		 public override int Update(Users obj)
		 {
			try
			{ 
			Command.CommandText="Proc_Users_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@Account", MySqlDbType.String));
				Command.Parameters["@Account"].Value=obj.Account;	
				Command.Parameters.Add(new MySqlParameter("@Password", MySqlDbType.String));
				Command.Parameters["@Password"].Value=obj.Password;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_Users_SelectObject
		 public override Users SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_Users_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			Users obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
			Command.CommandText="Proc_Users_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<Users> list= new List<Users>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						Users obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
			Command.CommandText="Proc_Users_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<Users> list= new List<Users>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						Users obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__Users_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<Users> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append("DataTableName");
				sb.Append(" (");

				sb.Append("Account");	
				sb.Append(",");		
				sb.Append("Password");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(Users item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.Account+"\"");
									sb.Append(",");
										sb.Append("\""+item.Password+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
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
