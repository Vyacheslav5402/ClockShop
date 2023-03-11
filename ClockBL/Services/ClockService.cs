using AutoMapper;
using ClockBL.ModelBL;
using ClockBL.Models;
using DAL;

namespace ClockBL.Services
{
    public interface IClockService
    {
        public void CreateClock();
        public List<ClockItemBLModel> GetAllClocks();
    }
    public class ClockService : IClockService
    {
        private readonly List<ClockItemBLModel> clocks = new List<ClockItemBLModel>();
        private ClockRepository clockRepository = new ClockRepository();
        private readonly IMapper _mapper;

        public ClockService()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfileBL());

            });

            _mapper = mapperConfig.CreateMapper();
        }

        public List<ClockItemBLModel> GetAllClocks()
        {
            var clocksDal = clockRepository.GetAllClocks();
            foreach (var or in clocksDal)
            {
                var clock = _mapper.Map<ClockItemBLModel>(or);
                var clockDes = _mapper.Map<DateDescriptionBLModel>(or.Description);
                clock.Description = clockDes;

                clocks.Add(clock);
            }


            return clocks;
        }

        public void CreateClock()
        {

            //CalculateDiscount()
            //save to db
        }

        private void CalculateDiscount()
        {

        }
    }
}