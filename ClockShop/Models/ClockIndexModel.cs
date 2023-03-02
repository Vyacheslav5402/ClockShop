namespace ClockShop.Models
{
    public class ClockIndexModel
    {
        public ClockIndexModel()
        {
            CurrentPage = 1;
        }

        //public bool IsBottleCountDesc { get; set; }
        public List<ClockItem> Clock { get; set; }
        public int CurrentPage { get; set; }
        public int AmountOfPage { get; set; }
    }
}
