using ClockShop.Models;
using System.Text.Json;

namespace ClockShop.Services
{
    public interface IAddDataClockList
    {
        void AddDataClock(List<ClockItem> clocks, List<DateDescriptionModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex);
    }
    public class DataClock : IAddDataClockList
    {
        public void AddDataClock(List<ClockItem> clocks, List<DateDescriptionModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex)
        {

            var model = clocks;
            var path = Path.Combine(Environment.CurrentDirectory, "clockList.json");
            string jsonClockList = System.IO.File.ReadAllText(path);

            if (!string.IsNullOrEmpty(jsonClockList))
            {
                model = JsonSerializer.Deserialize<ClockItem[]>(jsonClockList)?.ToList();
            }

            int id = 1;
            int i = 0;

            if (model != null)
            {

                while (id < maxClockAmount)
                {
                    if (i > jsonSizeIndex)
                    {
                        i = 0;
                    }

                    var modelItem = new ClockItem
                    {
                        Name = model[i].Name,
                        Prise = model[i].Prise,
                        Src = model[i].Src,
                        Id = id,
                        Description = dateDescriptions[i]
                    };

                    clocks.Add(modelItem);

                    id++;
                    i++;
                }
            }
        }
    }
}

