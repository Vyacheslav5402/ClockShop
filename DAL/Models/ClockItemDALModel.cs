namespace DAL.Models
{
    public class ClockItemDALModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateDescriptionDALModel Description { get; set; }
        public decimal Prise { get; set; }
        public string Src { get; set; }
        public bool AddToShoppingCart { get; set; }
    }
}
