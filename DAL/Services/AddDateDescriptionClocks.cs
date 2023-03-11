using DAL.Models;
using System.Text.Json;

namespace DAL.Services
{
    public interface IAddDataDescriptionClockList
    {
        void AddDataClock(List<ClockItemDALModel> clocks, List<DateDescriptionDALModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex);
    }
    public class AddDateDescriptionClocks : IAddDataDescriptionClockList
    {

        public void AddDataClock(List<ClockItemDALModel> clocks, List<DateDescriptionDALModel> dateDescriptions, int countItemOnThePage, int maxClockAmount, int jsonSizeIndex)
        {

            var model = dateDescriptions;
            var path = Path.Combine(Environment.CurrentDirectory, "descriptionClock.json");
            string descriptionClock = System.IO.File.ReadAllText(path);

            if (!string.IsNullOrEmpty(descriptionClock))
            {
                model = JsonSerializer.Deserialize<DateDescriptionDALModel[]>(descriptionClock)?.ToList();
            }

            if (model != null)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var modelItem = new DateDescriptionDALModel
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
