using AutoMapper;
using ClockBL.ModelBL;
using ClockBL.Models;
using ClockShop.Models;

namespace ClockShop
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClockItem, ClockItemBLModel>();
            CreateMap<ClockItemBLModel, ClockItem>();

            CreateMap<DateDescriptionModel, DateDescriptionBLModel>();
            CreateMap<DateDescriptionBLModel, DateDescriptionModel>();

        }
    }
}
