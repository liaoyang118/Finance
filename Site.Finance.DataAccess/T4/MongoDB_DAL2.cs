

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.XiaoShuo.DataAccess.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using DataAccess.Base;
using System.Configuration;
using System.Linq.Expressions;
using Site.Finance.DataAccess.Model;

namespace Site.Finance.DataAccess.Access
{


	[Serializable]
	public partial class Mongo_PersonBillAccess : Mongo_AccessBase<Mongo_PersonBill>,IDisposable
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
        public Mongo_PersonBillAccess(string dbName) 
        {
			DataTableName = "Mongo_PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_PersonFinance"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_PersonBillAccess()
        {
			DataTableName = "Mongo_PersonBill";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_PersonFinance"].ToString();
			 base.GetDatabase("Mongo_PersonFinance");
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
        ~Mongo_PersonBillAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_PersonBill_Insert
		 public override string Insert(Mongo_PersonBill obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_PersonBill_Delete
		 public override int Delete(Expression<Func<Mongo_PersonBill,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_PersonBill>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_PersonBill_Update
		 public override int Update(Expression<Func<Mongo_PersonBill, bool>> filter,Mongo_PersonBill obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_PersonBill>(filter,Builders<Mongo_PersonBill>.Update.Set("Id",obj.Id).Set("u_id",obj.u_id).Set("io_flag",obj.io_flag).Set("total_money",obj.total_money).Set("item_name",obj.item_name).Set("item_money",obj.item_money).Set("money_type",obj.money_type).Set("create_time",obj.create_time).Set("remark",obj.remark));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_PersonBill_SelectObject
		 public override Mongo_PersonBill SelectObject(Expression<Func<Mongo_PersonBill, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
                Mongo_PersonBill obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_PersonBill_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_PersonBill> Select(Expression<Func<Mongo_PersonBill, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
                IList<Mongo_PersonBill> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_PersonBill_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_PersonBill> Select(Expression<Func<Mongo_PersonBill, bool>> filter,SortDefinition<Mongo_PersonBill> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
                IList<Mongo_PersonBill> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_PersonBill_SelectPage
		 public override IList<Mongo_PersonBill> SelectPage(SortDefinition<Mongo_PersonBill> order, Expression<Func<Mongo_PersonBill, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
                var result = collection.Find(filter).Sort(order);
                rowCount = (int)result.CountDocuments();

                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 07 BatchInsert

        public override void BatchInsert(IList<Mongo_PersonBill> list )
        {
            try
            {
                IMongoCollection<Mongo_PersonBill> collection = Database.GetCollection<Mongo_PersonBill>(DataTableName);
                collection.InsertMany(list);
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层：" + e.Message);
            }
        }

        #endregion

    }

	[Serializable]
	public partial class Mongo_UsersAccess : Mongo_AccessBase<Mongo_Users>,IDisposable
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
        public Mongo_UsersAccess(string dbName) 
        {
			DataTableName = "Mongo_Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_PersonFinance"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_UsersAccess()
        {
			DataTableName = "Mongo_Users";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_PersonFinance"].ToString();
			 base.GetDatabase("Mongo_PersonFinance");
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
        ~Mongo_UsersAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_Users_Insert
		 public override string Insert(Mongo_Users obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_Users_Delete
		 public override int Delete(Expression<Func<Mongo_Users,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_Users>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_Users_Update
		 public override int Update(Expression<Func<Mongo_Users, bool>> filter,Mongo_Users obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_Users>(filter,Builders<Mongo_Users>.Update.Set("Id",obj.Id).Set("Account",obj.Account).Set("Password",obj.Password));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_Users_SelectObject
		 public override Mongo_Users SelectObject(Expression<Func<Mongo_Users, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
                Mongo_Users obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_Users_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Users> Select(Expression<Func<Mongo_Users, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
                IList<Mongo_Users> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_Users_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Users> Select(Expression<Func<Mongo_Users, bool>> filter,SortDefinition<Mongo_Users> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
                IList<Mongo_Users> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_Users_SelectPage
		 public override IList<Mongo_Users> SelectPage(SortDefinition<Mongo_Users> order, Expression<Func<Mongo_Users, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
                var result = collection.Find(filter).Sort(order);
                rowCount = (int)result.CountDocuments();

                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 07 BatchInsert

        public override void BatchInsert(IList<Mongo_Users> list )
        {
            try
            {
                IMongoCollection<Mongo_Users> collection = Database.GetCollection<Mongo_Users>(DataTableName);
                collection.InsertMany(list);
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层：" + e.Message);
            }
        }

        #endregion

    }
}
