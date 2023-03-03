using ClockShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ClockShop.Controllers
{
    public class ClockController : Controller
    {
        public static List<ClockItem> clocks = new List<ClockItem>();
        public static List<DateDescriptionModel> dateDescriptions = new List<DateDescriptionModel>();
        public int _countItemOnThePage = 12;
        public static int img = 0;
        public ClockController()
        {

            if (!clocks.Any())
            {
                var model = clocks;
                var path = Path.Combine(Environment.CurrentDirectory, "clockList.json");
                string jsonClockList = System.IO.File.ReadAllText(path);
                model = System.Text.Json.JsonSerializer.Deserialize<ClockItem[]>(jsonClockList).ToList();

                path = Path.Combine(Environment.CurrentDirectory, "descriptionClock.json");
                string descriptionClock = System.IO.File.ReadAllText(path);
                dateDescriptions = System.Text.Json.JsonSerializer.Deserialize<DateDescriptionModel[]>(descriptionClock).ToList();
                int id = 1;
                int i = 0;
                bool run = true;



                while (run)
                {
                    if (id > 150)
                    {
                        run = false;
                        break;
                    }
                    if (i > 8)
                    {
                        i = 0;

                    }
                    var modelItem = new ClockItem
                    {
                        Name = model[i].Name,
                        Prise = model[i].Prise,
                        Src = model[i].Src,
                        Id = id
                    };
                    clocks.Add(modelItem);
                    id++;
                    i++;
                }
            }
        }
        public ActionResult Index(bool isAjax = false, int currentPage = 1, int skipItems = 0)
        {

            ClockIndexModel model = new ClockIndexModel();
            model.Clock = clocks;
            var filteredOrders = clocks;

            var totalPages = (int)Math.Ceiling(clocks.Count() / (double)_countItemOnThePage);
            int asd = totalPages - currentPage;
            model.AmountOfPage =totalPages ;
            if (asd>img)
            {
                model.CurrentPage = asd - img;
            }
            else
            {
                model.allPagesViews = true;
                img = 1;
                return View("~/Views/Partials/IndexTable.cshtml", model);

            }

            if (currentPage != 1)
            {
                skipItems = (currentPage - 1) * _countItemOnThePage;
            }

            _countItemOnThePage = skipItems + _countItemOnThePage;
            model.Clock = filteredOrders.Take(_countItemOnThePage).ToList();


            if (isAjax)
            {
                if (img <1)
                {
                    img++;
                }
                return View("~/Views/Partials/IndexTable.cshtml", model);
                
            }
            
            return View(model);
        }

        public ActionResult PageNavigation(int currentPage = 1)
        {
            ClockIndexModel model = new ClockIndexModel();
            model.Clock = clocks;
            var filteredOrders = clocks;
            var totalPages = (int)Math.Ceiling(clocks.Count() / (double)_countItemOnThePage);

            int skipItems = 0;

            if (currentPage != 1)
            {
               skipItems = (currentPage - 1) * _countItemOnThePage;
            }

            model.Clock = filteredOrders.Skip(skipItems).Take(_countItemOnThePage).ToList();

            return View("~/Views/Partials/IndexTable.cshtml", model);
        }
    }
}
