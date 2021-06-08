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
           
        }
    }
}
