using ClockShop.Models;
using ClockShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClockShop.Controllers
{
    public class ClockController : Controller
    {
        public static List<ClockItem> clocks = new List<ClockItem>();
        public static List<DateDescriptionModel> dateDescriptions = new List<DateDescriptionModel>();
        public int countItemOnThePage = 12;
        public static int img = 0;
        public int maxClockAmount = 150;
        public int jsonSizeIndex = 8;
        public static int amountOfPage;
        public static int startPageClock = 0;

        public ClockController()
        {
            if (!clocks.Any())
            {
                AddDateDescriptionClocks dateDescriptionClocks = new AddDateDescriptionClocks();
                dateDescriptionClocks.AddDataClock(clocks, dateDescriptions, countItemOnThePage, maxClockAmount, jsonSizeIndex);

                DataClock dataClock = new DataClock();
                dataClock.AddDataClock(clocks, dateDescriptions, countItemOnThePage, maxClockAmount, jsonSizeIndex);
                amountOfPage = clocks.Count / countItemOnThePage;
            }
        }

        public ActionResult Index(bool isAjax = false, int currentPage = 1)
        {
            ClockIndexModel model = new ClockIndexModel();
            model.Clock = clocks;
            model.PageCount = startPageClock;
            model.AmountOfPage = amountOfPage;

            ShowMoreOnPage showMore = new ShowMoreOnPage();
            model = showMore.ShowMorePage(clocks, model, countItemOnThePage, img, currentPage);
            startPageClock = model.PageCount;

            if (isAjax)
            {
                if (img < 1)
                {
                    img++;
                }

                return View("~/Views/Clock/Index.cshtml", model);
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = clocks.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public ActionResult Buy(int id)
        {
            var model = clocks.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public ActionResult PageNavigation(int currentPage)
        {
            startPageClock = 1;
            int startPage = 1;

            ClockIndexModel model = new ClockIndexModel
            {
                Clock = clocks
            };

            var filteredOrders = clocks;

            int skipItems = 0;

            if (currentPage != startPage)
            {
                skipItems = (currentPage - 1) * countItemOnThePage;
            }

            model.Clock = filteredOrders.Skip(skipItems).Take(countItemOnThePage).ToList();
            model.AmountOfPage = amountOfPage;

            return View("~/Views/Clock/Index.cshtml", model);
        }

    }
}
