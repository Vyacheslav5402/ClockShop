using ClockShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClockShop.Controllers
{
    public class ClockController : Controller
    {
        public List<ClockItem> clocks = new List<ClockItem>();
        public ClockController()
        {
            Random rnd = new Random();

            for (int i = 1; i < 21; i++)
            {
                var clockItem1 = new ClockItem
                {
                    Id = i,
                    Description = "Test",
                    Mechanismtype = "cvarc",
                    Prise = rnd.Next(100, 300)
                };
                if (i % 5 == 0)
                {
                    clockItem1.Src = "http://placekitten.com/g/161/120";
                    clockItem1.Name = "ЧАСЫ CASIO ";
                }
                if (i % 3 == 0)
                {
                    clockItem1.Src = "http://placekitten.com/g/162/120";
                    clockItem1.Name = "ЧАСЫ BRUNO SOHNLE ARMIDA ";
                }
                if (i % 2 == 0)
                {
                    clockItem1.Src = "http://placekitten.com/g/163/120";
                    clockItem1.Name = "ЧАСЫ ATLANTIC";
                }
                else
                {
                    clockItem1.Src = "http://placekitten.com/g/161/120";
                    clockItem1.Name = "ЧАСЫ GSHOK ";
                }
                clocks.Add(clockItem1);
            }
        }
        private readonly int _countItemOnThePage = 6;
        public IActionResult Index()
        {
            ClockIndexModel model = new ClockIndexModel();
            model.Clock = clocks;

            return View(model);
        }
    }
}
