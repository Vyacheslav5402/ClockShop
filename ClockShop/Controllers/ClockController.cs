using ClockShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClockShop.Controllers
{
    public class ClockController : Controller
    {
        public List<ClockItem> clocks = new List<ClockItem>();
        public List<DateDescriptionModel> dateDescriptions = new List<DateDescriptionModel>();
        private readonly int _countItemOnThePage = 8;
        public ClockController()
        {
            if (!clocks.Any())
            {
                var path = Path.Combine(Environment.CurrentDirectory, "clockList.json");
                string jsonClockList = System.IO.File.ReadAllText(path);
                clocks = System.Text.Json.JsonSerializer.Deserialize<ClockItem[]>(jsonClockList).ToList();

                path = Path.Combine(Environment.CurrentDirectory, "descriptionClock.json");
                string descriptionClock = System.IO.File.ReadAllText(path);
                dateDescriptions = System.Text.Json.JsonSerializer.Deserialize<DateDescriptionModel[]>(descriptionClock).ToList();

                
            }

            Random rnd = new Random();

            //for (int i = 1; i < 21; i++)
            //{
            //    var clockItem = new ClockItem
            //    {
            //        Id = i,
            //        Description = "Test",
            //        Mechanismtype = "cvarc",
            //        Prise = rnd.Next(100, 300)
            //    };
            //    if (i % 5 == 0)
            //    {
            //        clockItem.Src = "http://placekitten.com/g/161/120";
            //        clockItem.Name = "ЧАСЫ CASIO ";
            //    }
            //    if (i % 3 == 0)
            //    {
            //        clockItem.Src = "http://placekitten.com/g/162/120";
            //        clockItem.Name = "ЧАСЫ BRUNO SOHNLE ARMIDA ";
            //    }
            //    if (i % 2 == 0)
            //    {
            //        clockItem.Src = "http://placekitten.com/g/163/120";
            //        clockItem.Name = "ЧАСЫ ATLANTIC";
            //    }
            //    else
            //    {
            //        clockItem.Src = "http://placekitten.com/g/161/120";
            //        clockItem.Name = "ЧАСЫ GSHOK ";
            //    }
            //    clocks.Add(clockItem);
            //}
        }
        public IActionResult Index(int currentPage = 1)
        {
            ClockIndexModel model = new ClockIndexModel();
            model.Clock = clocks;

            var totalPages = (int)Math.Ceiling(clocks.Count() / (double)_countItemOnThePage);
            model.AmountOfPage = totalPages;

            int skipItems = 0;

            if (currentPage != 1)
            {
                skipItems = (currentPage - 1) * _countItemOnThePage;
            }

            var filteredClocks = clocks;

            model.Clock = filteredClocks.Skip(skipItems).Take(_countItemOnThePage).ToList();

            return View(model);
        }
    }
}
