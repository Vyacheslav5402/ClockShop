using DAL.Models;
using DAL.Services;

namespace DAL
{
    public interface IClockRepository
    {
        List<ClockItemDALModel> GetAllClocks();
    }
    public class ClockRepository : IClockRepository
    {
        public static List<DateDescriptionDALModel> dateDescriptions = new List<DateDescriptionDALModel>();
        private int countItemOnThePage = 12;
        private int maxClockAmount = 150;
        private int jsonSizeIndex = 8;

        private List<ClockItemDALModel> clocks = new List<ClockItemDALModel>();
        public List<ClockItemDALModel> GetAllClocks()
        {
            if (!clocks.Any())
            {
                AddDateDescriptionClocks dateDescriptionClocks = new AddDateDescriptionClocks();
                dateDescriptionClocks.AddDataClock(clocks, dateDescriptions, countItemOnThePage, maxClockAmount, jsonSizeIndex);

                DataClock dataClock = new DataClock();
                dataClock.AddDataClock(clocks, dateDescriptions, countItemOnThePage, maxClockAmount, jsonSizeIndex);
            }

            return clocks;
        }

    }
}