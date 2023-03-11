using AutoMapper;
using ClockBL.ModelBL;
using ClockBL.Models;
using DAL.Models;

namespace ClockBL
{
    public class AutomapperProfileBL : Profile
    {

        public AutomapperProfileBL()
        {
            CreateMap<ClockItemDALModel, ClockItemBLModel>();
            CreateMap<ClockItemBLModel, ClockItemDALModel>();

            CreateMap<DateDescriptionDALModel, DateDescriptionBLModel>();
            CreateMap<DateDescriptionBLModel, DateDescriptionDALModel>();
        }
    }
}
