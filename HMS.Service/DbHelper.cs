using Dapper;
using HMS.Domain;
using System;
using System.Collections.Generic;
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
    public class DbHelper : IDbHelper
    {
        string connectionString;
        public DbHelper(ConnectionSettings connectionSettings)
        {
            connectionString = connectionSettings.DefaultConnection;
        }
        public DbHelper()
        {

        }
       
        internal void Add(string insertQuery, object fileUpload)
        {
            throw new NotImplementedException();
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
            using (var db = new SqlConnection(connectionString))
            {
                var result = db.Execute(query, model);
            }
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
                result = connection.Query<T>(StateSelectQuery,obj).ToList();
            }
            return result;
        }
    }
}
