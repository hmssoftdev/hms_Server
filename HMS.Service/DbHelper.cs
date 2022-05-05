using Dapper;
using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HMS.Service
{
    public interface IDbHelper
    {

        public IList<T> FetchData<T>(string StateSelectQuery);
        public IList<T> FetchDataByParam<T>(string StateSelectQuery, object obj);
        public int GetCount(string query, object obj);
        public string GetString(string query, object obj);
        public void Add<Model>(string query, Model model);
        public void Update<Model>(string query, Model model);
        public void Delete<Model>(string query, Model model);

    }
    public interface IDbHelperOrder : IDbHelper
    {
        public int OrderTransaction(DishOrder order, string parentQuery, string itemQuery, string statusQuery, string orderTableAddQuery);
        public DishOrder GetOrderDetailFromTableId(int tableId);
    }

    public class DbHelper : IDbHelper, IDbHelperOrder
    {
        string connectionString;
        public DbHelper(ConnectionSettings connectionSettings)
        {
            connectionString = connectionSettings.DefaultConnection;
        }
        public DbHelper()
        {

        }

        // only when deplyed
        public IList<T> FetchData<T>(string StateSelectQuery)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<T>(StateSelectQuery).ToList();
            }
            return result;
        }

        public void Add<Model>(string query, Model model)
        {
            using var db = new SqlConnection(connectionString);
            var result = db.Execute(query, model);
        }

        public void Update<Model>(string query, Model model)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var result = db.Execute(query, model);
            }
        }

        public void Delete<Model>(string query, Model model)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var result = db.Execute(query, model);
            }
        }

        public IList<T> FetchDataByParam<T>(string StateSelectQuery, object obj)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<T>(StateSelectQuery, obj).ToList();
            }
            return result;
        }

        public int OrderTransaction(DishOrder order, string parentQuery,string itemQuery, string statusQuery, string orderTableAddQuery )
        {
            int newId;
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            var result = connection.Execute(parentQuery, order, transaction);
            newId = Convert.ToInt32(connection.ExecuteScalar<object>("SELECT @@IDENTITY", null, transaction: transaction));
            
            order.OrderItems.ForEach(x =>
            {
                x.OrderID = newId;
		x.KotPrinted = true;
                int affectedRows = connection.Execute(sql: itemQuery, x, transaction);
            });
            order.OrderStatus.ForEach(x =>
            {
                x.OrderId = newId;
                var affectedRows = connection.Execute(statusQuery, x, transaction);
            });

            order.TableIds.ForEach(x =>
            {
                var TableOrder = new OrderTable { CreatedBy = order.CreatedBy, OrderId = newId, TableId = x, IsActive = true };
                var affectedRows = connection.Execute(orderTableAddQuery, TableOrder, transaction);
            });
            transaction.Commit();
            return newId;



        }

        public DishOrder GetOrderDetailFromTableId(int tableId)
        {
            var orderSqlObj = new { tableId = tableId };
            var orderSql = @"Select top 1 do.* , u.Name ,u.Contact  from DishOrder do
                            inner join orderTable ot
                            inner join HotelTable ht on ht.id = ot.TableId
                            on ot.OrderId = do.id 
							left join dbo.Users u on do.userId= u.id
                            where ot.TableId = @tableId 
                            order by ot.id desc";
            using SqlConnection connection = new SqlConnection(connectionString);
            var order = connection.QueryFirstOrDefault<DishOrder>(orderSql, orderSqlObj);
            {
                if (order == null)
                    return new DishOrder();
                var orderItemSql = "select d.Name, oi.* from OrderItem oi inner join Dish d on oi.ProductId = d.Id where OrderID = @orderId";
                var orderItemSqlObj = new { orderId = order.Id };
                var items = connection.Query<OrderItem>(orderItemSql, orderItemSqlObj).ToList();
                order.OrderItems = items;
            }
            {
                var orderStatusSql = "select * from OrderStatus where OrderID = @orderId";
                var orderItemSqlObj = new { orderId = order.Id };
                var status = connection.Query<OrderStatus>(orderStatusSql, orderItemSqlObj).ToList();
                order.OrderStatus = status;
            }
            {
                var orderTableSql = "select TableId from ordertable where OrderId = @orderId";
                var orderItemSqlObj = new { orderId = order.Id };
                var tableIds = connection.Query<int>(orderTableSql, orderItemSqlObj).ToList();
                order.TableIds = tableIds;
            }
            return order;
        }

        public int GetCount(string query, object obj)
        {
            int result;
            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.ExecuteScalar<int>(query,obj);
            }
            return result;
        }

        public string GetString(string query, object obj)
        {
            string result;
            using var connection = new SqlConnection(connectionString);
            result = connection.ExecuteScalar<string>(query, obj);
            return result;
        }
    }
}
