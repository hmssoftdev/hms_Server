using Dapper;
using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HMS.Service
{
    public class DbHelper
    {
        //string connectionString = "Data Source=DESKTOP-9IJKFVB;Initial Catalog=hms;Integrated Security=True";
        // only when deplyed
        string connectionString = "Data Source=148.72.232.168;Initial Catalog=hms_db;Integrated Security=False;User ID=hms_admin;password=*2mf6yL2;Connect Timeout=15;Encrypt=False;Packet Size=4096";
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

        internal void Add(object insertQuery, BusinessCategory businessCategory)
        {
            throw new NotImplementedException();
        }
    }
}
