using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class MasterService :IMasterService
    {
        DbHelper dbHelper = new DbHelper();
        string StateSelectQuery = @"SELECT [Id]
                                  ,[IsActive]
                                  ,[CreatedOn]
                                  ,[CreatedBy]
                                  ,[UpdatedOn]
                                  ,[UpdatedBy]
                                  ,[Name]
                              FROM[dbo].[StateMaster]";
        string CitySelectQuery =@"SELECT [Id]
                              ,[IsActive]
                              ,[CreatedOn]
                              ,[CreatedBy]
                              ,[UpdatedOn]
                              ,[UpdatedBy]
                              ,[Name]
                              ,[StateId]
                          FROM[dbo].[CityMaster]";
      
       

        public IList<StateMaster> GetAllState<StateMaster>()
        {
            var StateMasterList = dbHelper.FetchData<StateMaster>($"{StateSelectQuery}");
            return StateMasterList;
        }
        public IList<CityMaster> GetAllCity<CityMaster>()
        {
            var CityMasterList = dbHelper.FetchData<CityMaster>($"{CitySelectQuery}");
            return CityMasterList;
        }

        
    }
}
