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


        // get order detail from the table id 
        //Select top 1 do.* from DishOrder do
        //inner join orderTable ot
        //on ot.OrderId = do.id
        //where ot.TableId = 22
        //order by ot.id desc
        //
        // fetch dish id from the order menu
        // fetch dish from the list
        // return values

        public DishOrder GetOrderDetailFromTableId(int tableId)
        {
            var orderSqlObj = new { tableId = tableId };
            var orderSql = @"Select top 1 do.* from DishOrder do
                            inner join orderTable ot
                            inner join HotelTable ht on ht.id = ot.TableId
                            on ot.OrderId = do.id 
                            where ot.TableId = @tableId 
                            order by ot.id desc";

            var orderItemSql = "select * from OrderItem where OrderID = @orderId";
            using SqlConnection connection = new SqlConnection(connectionString);
            var order = connection.QueryFirstOrDefault<DishOrder>(orderSql,orderSqlObj);
            var orderItemSqlObj = new { orderId = order.Id };
            var items = connection.Query<OrderItem>(orderItemSql, orderItemSqlObj).ToList();
            order.OrderItems = items;
            return order;
        }
    }
}
