using ClockShop.Models;

namespace ClockShop.Services
{
    public class ShowMoreOnPage
    {
        public ClockIndexModel ShowMorePage(List<ClockItem> clocks, ClockIndexModel model, int countItemOnThePage, int img, int currentPage = 1, bool shoppingCart = false)
        {
            model.Clock = clocks;
            var filteredOrders = clocks;

            if (model.PageCount <= model.AmountOfPage && shoppingCart == false)
            {
                model.PageCount++;
            }

            currentPage = model.PageCount;
            var totalPages = (int)Math.Ceiling(clocks.Count() / (double)countItemOnThePage);
            int asd = totalPages - currentPage;
            model.AmountOfPage = totalPages;

            if (asd > img)
            {
                model.CurrentPage = asd - img;
            }
            else
            {
                model.allPagesViews = true;
                img = 1;

                return model;
            }

            int skipItems = 0;

            if (currentPage != 1)
            {
                skipItems = (currentPage - 1) * countItemOnThePage;
            }

            countItemOnThePage = skipItems + countItemOnThePage;
            model.Clock = filteredOrders.Take(countItemOnThePage).ToList();

            return model;
        }
    }
}
