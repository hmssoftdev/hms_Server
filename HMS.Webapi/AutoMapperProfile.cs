using AutoMapper;

namespace HMS.Webapi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HMS.Domain.Dish, HMS.Domain.Model.Dish>();
            CreateMap<HMS.Domain.UserConfig, HMS.Domain.Model.UserConfig>();
            CreateMap<HMS.Domain.Admin, HMS.Domain.Model.Admin>();
            CreateMap<HMS.Domain.DishCategory, HMS.Domain.Model.DishCategory>();
            CreateMap<HMS.Domain.StateMaster, HMS.Domain.Model.StateMaster>();
            CreateMap<HMS.Domain.CityMaster, HMS.Domain.Model.CityMaster>();
            CreateMap<HMS.Domain.UserFeedback, HMS.Domain.Model.UserFeedback>();
            CreateMap<HMS.Domain.BusinessCategory, HMS.Domain.Model.BusinessCategory>();
            CreateMap<HMS.Domain.User, HMS.Domain.Model.User>();

            CreateMap<HMS.Domain.DishOrder, HMS.Domain.Model.DishOrder>();
            CreateMap<Domain.OrderItem, HMS.Domain.Model.OrderItem>();
            CreateMap<Domain.OrderStatus, Domain.Model.OrderStatus>();
            CreateMap<HMS.Domain.HotelTable, HMS.Domain.Model.HotelTable>();
           
        }
    }
}
