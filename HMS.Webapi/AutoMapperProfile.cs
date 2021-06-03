using AutoMapper;

namespace HMS.Webapi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HMS.Domain.Model.Dish, HMS.Domain.Dish>();
            CreateMap<HMS.Domain.Model.Client, HMS.Domain.Client>();
            CreateMap<HMS.Domain.Model.UserConfig, HMS.Domain.UserConfig>();
            CreateMap<HMS.Domain.Model.ClientCategory, HMS.Domain.ClientCategory>();
            CreateMap<HMS.Domain.Model.ClientBankDetail, HMS.Domain.ClientBankDetail>();
            CreateMap<HMS.Domain.Model.DishCategory, HMS.Domain.DishCategory>();
        }
    }
}
