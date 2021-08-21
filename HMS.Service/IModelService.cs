using HMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Service
{
    public interface IModelService
    {
        IList<T> GetAll<T>();
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
    public interface IUserFeedbackService : IModelService { }
    public interface IBusinessCategoryService : IModelService { }
    public interface IHotelService : IModelService { }
   
    public interface IUserService : IModelService {
       User ValidateUser(string userName, string pwd);
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
