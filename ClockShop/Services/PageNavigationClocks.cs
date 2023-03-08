using ClockShop.Models;

namespace ClockShop.Services
{
    public class PageNavigationClocks
    {
        public ClockIndexModel PageNavigation(List<ClockItem> clocks, ClockIndexModel model, int countItemOnThePage, int currentPage, int startPageClock, int amountOfPage)
        {
            startPageClock = 1;
            int startPage = 1;

            var filteredOrders = clocks;

            int skipItems = 0;

            if (currentPage != startPage)
            {
                skipItems = (currentPage - 1) * countItemOnThePage;
            }

            model.Clock = filteredOrders.Skip(skipItems).Take(countItemOnThePage).ToList();
            model.AmountOfPage = amountOfPage;

            return model;
        }
    }
}
