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
    } 
    public interface IDishCategoryService: IModelService { }

    public interface IOrderService : IModelService {
        public void AddStatus(OrderStatus status);
        public void Add(OrderItem item);
        public void Update(OrderItem item);
        public List<OrderStatus> GetStatusByOrderId(int OrderId);
        public List<Domain.Model.OrderItem> GetOrderItemByOrderId(int OrderId);
        public void ReleaseTable(int OrderId);
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
    }
    public interface IMasterService
    {
        IList<T> GetAllState<T>();
        IList<T> GetAllCity<T>();
    }

    public interface IInvoice {
        void GetInvoice(Admin admin,User user);
  }
     

    
}
