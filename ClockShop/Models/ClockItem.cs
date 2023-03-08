namespace ClockShop.Models
{
    public class ClockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateDescriptionModel Description { get; set; }
        public decimal Prise { get; set; }
        public string Src { get; set; }
        public bool AddToShoppingCart { get; set; }

    }
}
