using ClockShop.Models;
using System.Text.Json;

namespace ClockShop.Services
{
    public interface IAddDataDescriptionClockList
    {
        void AddDataClock(List<ClockItem> clocks, List<DateDescriptionModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex);
    }
    public class AddDateDescriptionClocks : IAddDataDescriptionClockList
    {

        public void AddDataClock(List<ClockItem> clocks, List<DateDescriptionModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex)
        {

            var model = dateDescriptions;
            var path = Path.Combine(Environment.CurrentDirectory, "descriptionClock.json");
            string descriptionClock = System.IO.File.ReadAllText(path);

            if (!string.IsNullOrEmpty(descriptionClock))
            {
                model = JsonSerializer.Deserialize<DateDescriptionModel[]>(descriptionClock)?.ToList();
            }
            if (model != null)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var modelItem = new DateDescriptionModel
                    {
                        Material = model[i].Material,
                        Brand = model[i].Brand,
                        Country = model[i].Country,
                        Gender = model[i].Gender,
                        Guarantee = model[i].Guarantee,
                        Id = model[i].Id,
                        Mechanism = model[i].Mechanism
                    };
                    dateDescriptions.Add(modelItem);
                }

            }
        }
    }
}
