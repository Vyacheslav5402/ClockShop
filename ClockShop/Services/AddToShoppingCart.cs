using ClockShop.Models;

namespace ClockShop.Services
{
    public interface IAddToShoppingCart
    {
        void AddToShoppingCarts(List<ClockItem> clocks, int id);
    }
    public class AddToShoppingCart : IAddToShoppingCart
    {
        public void AddToShoppingCarts(List<ClockItem> clocks, int id)
        {
            var model = clocks.FirstOrDefault(x => x.Id == id);

            if (model != null && model.AddToShoppingCart != true)
            {
                clocks[model.Id - 1].AddToShoppingCart = true;
            }
            else
            {
                if (model != null)
                {
                    clocks[model.Id - 1].AddToShoppingCart = false;
                }
            }
        }
    }
}
