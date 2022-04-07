using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public class UserSettingService : IUserSettingService
    {
        IDbHelper dbHelper;

        string selectById = @"Select Id,
                        UserId,
                        Theme,
                        MenuDisplay,
                        BillWithGST,
                        BillWithCustomer,
                        BillWithLOGO,
                        BillWithSign,
                        BillWithSeal,
                        Language,
                        ActiveOrderFlow,
                        DirectKOTBillPrint,
                        BillPrintAndKOT from Usersettings where UserId = @UserId";
        string updateQuery = @"update UserSettings set
                                Theme = @Theme,
                                MenuDisplay = @MenuDisplay,
                                BillWithGST = @BillWithGST,
                                BillWithCustomer = @BillWithCustomer,
                                BillWithLOGO =@BillWithLOGO,
                                BillWithSign =@BillWithSign,
                                BillWithSeal = @BillWithSeal,
                                Language = @Language,
                                ActiveOrderFlow = @ActiveOrderFlow,
                                DirectKOTBillPrint = @DirectKOTBillPrint,
                                BillPrintAndKOT =@BillPrintAndKOT
                                where UserId = @UserId";
        string insertQuery = @"insert into UserSettings (Theme ,MenuDisplay ,BillWithGST,BillWithCustomer  ,BillWithLOGO,BillWithSign,BillWithSeal,UserId,Language,ActiveOrderFlow,DirectKOTBillPrint,BillPrintAndKOT)
                               values (@Theme,@MenuDisplay,@BillWithGST,@BillWithCustomer,@BillWithLOGO,@BillWithSign,@BillWithSeal,@UserId,@Language,@ActiveOrderFlow,@DirectKOTBillPrint,@BillPrintAndKOT )";
        public UserSettingService(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        public void Add(IModel model)
        {
            var userSettings = (UserSettings)model;
            dbHelper.Add<UserSettings>(insertQuery, userSettings);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IList<UserSettings> GetAllByHotelId<UserSettings>(int id)
        {
         
            throw new NotImplementedException();

        }

        public IList<UserSettings> GetById<UserSettings>(int id)
        {
            var obj = new
            {
                UserId = id,
            };
            var UserSettingsList = dbHelper.FetchDataByParam<UserSettings>(selectById, obj);
            return UserSettingsList;
        }

        public void Update(IModel model)
        {
            var userSettings = (UserSettings)model;
            dbHelper.Update<UserSettings>(updateQuery, userSettings);
        }
    }
}
