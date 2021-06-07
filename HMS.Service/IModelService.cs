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
        void Updat(IModel model);
        void Delete(int id);
    }

    public interface IDishService: IModelService { } 
    public interface IUserConfigService: IModelService { } 
}
