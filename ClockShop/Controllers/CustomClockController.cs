using ClockShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClockShop.Controllers
{
    public class CustomClockController : Controller
    {
        public static List<CustomClockModel> customClocks = new List<CustomClockModel>();
        public static int startId = 0;

        // GET: CustomClockController
        public ActionResult Index()
        {
            CustomIndexModel model = new CustomIndexModel();
            model.ClockModels = customClocks;

            return View(model);
        }

        // GET: CustomClockController/Details/5
        public ActionResult Details(int id)
        {
            var clock = customClocks.FirstOrDefault(x => x.Id == id);
            return View(clock);
        }

        // GET: CustomClockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomClockController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomClockModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                var id = customClocks.Any() ? customClocks.Max(item => item.Id) + 1 : 1;
                item.Id = id;
                customClocks.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomClockController/Edit/5
        public ActionResult Edit(int id)
        {
            var clock = customClocks.FirstOrDefault(x => x.Id == id);
            return View();
        }

        // POST: CustomClockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditClockItemModel model)
        {
            var clock = customClocks?.FirstOrDefault(x => x.Id == id);

            if (clock != null)
            {
                clock.Watchband = model.Watchband;
                clock.ClockHands = model.ClockHands;
                clock.ClockFase = model.ClockFase;
                clock.ClockCase = model.ClockCase;
            }
            else
            {
                return BadRequest();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomClockController/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedClock = customClocks.FirstOrDefault(clock => clock.Id == id);
            return View(deletedClock);
        }

        // POST: CustomClockController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deletedClock = customClocks.FirstOrDefault(clock => clock.Id == id);

            if (deletedClock != null)
            {
                customClocks.Remove(deletedClock);
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
