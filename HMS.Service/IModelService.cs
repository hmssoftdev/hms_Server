using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public interface IModelService
    {
        IList<T> GetAll<T>();

        IList<T> GetAllByHotelId<T>(int id);

        IList<T> GetById<T>(int id);
        void Add(IModel model);
        void Update(IModel model);
        void Delete(int id);
    }

    public interface IDishService: IModelService { } 
    public interface IUserConfigService: IModelService { } 
    public interface IAdminService: IModelService {
      void  UpdateSubscriptionId(IModel model);
       Admin GetByUserId(int userId);
    } 
    public interface IDishCategoryService: IModelService { }

    public interface IOrderService : IModelService {
        public void AddStatus(OrderStatus status);
        public void Add(OrderItem item);
        public int AddDataAndReturnId(IModel model);

        public void Update(OrderItem item);
        void UpdatePayementModeId(IModel model);
        public List<OrderStatus> GetStatusByOrderId(int OrderId);
        public List<Domain.Model.OrderItem> GetOrderItemByOrderId(int OrderId);
        public void ReleaseTable(int OrderId);
        public DishOrder GetOrderByTableId(int tableid);
        IList<DishOrder> GetAllByHotelQueryAndDateRange<DishOrder>(int id, string maxDate, string minDate);
    }


    public interface IUserFeedbackService : IModelService { }
    public interface IBusinessCategoryService : IModelService { }
    public interface IHotelTableService : IModelService
    {
       // void Update(Hotel hotel);
        void UpdateBookedSeat(IModel model);
        void UpdateSeatId(IModel model);

    }
    public interface IUserService : IModelService {
       User ValidateUser(string userName, string pwd);
        User ValidateUser(int id);
        IList<User> GetAllAdmin<User>();
        bool UpdatePassword(string oldPwd, string newPwd,int userId);
        string ForgotPassword(string email);
    }
    public interface IMasterService
    {
        IList<T> GetAllState<T>();
        IList<T> GetAllCity<T>();
    }

    public interface IInvoice {
        void GetInvoice(Admin admin,User user);
  }

    public interface IEmailService
    {
        void SendForgotPassword(string to, string subject, string html, string from = null);
        
    }

    public interface IUserSettingService : IModelService { }



}
