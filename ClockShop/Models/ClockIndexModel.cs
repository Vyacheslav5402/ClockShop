namespace ClockShop.Models
{
    public class ClockIndexModel
    {
        public ClockIndexModel()
        {
            CurrentPage = 1;
        }

        public List<ClockItem> Clock { get; set; }
        public List<DateDescriptionModel> DateDescription { get; set; }
        public int CurrentPage { get; set; }
        public int AmountOfPage { get; set; }
        public bool allPagesViews = false;
    }
}
