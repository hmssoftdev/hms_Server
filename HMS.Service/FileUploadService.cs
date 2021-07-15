using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class FileUploadService : IFileUploadService
    {
        DbHelper dbHelper = new DbHelper();
        string selectQuery = "";
        string insertQuery = "";
        string updateQuery = "";

        public void Add(IModel model)
        {
            var dish = (UploadFile)model;
            dish.IsActive = true;
           // dbHelper.Add(insertQuery,fileUpload);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
