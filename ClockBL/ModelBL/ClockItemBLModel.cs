using ClockBL.Models;

namespace ClockBL.ModelBL
{
    public class ClockItemBLModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateDescriptionBLModel Description { get; set; }
        public decimal Prise { get; set; }
        public string Src { get; set; }
        public bool AddToShoppingCart { get; set; }
    }
}
