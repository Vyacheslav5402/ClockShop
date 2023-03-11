using ClockBL.Models;

namespace ClockBL.ModelBL
{
    public class ClockIndexBLModel
    {
        public ClockIndexBLModel()
        {
            CurrentPage = 1;
        }

        public List<ClockItemBLModel> Clock { get; set; }
        public List<DateDescriptionBLModel> DateDescription { get; set; }
        public int CurrentPage { get; set; }
        public int AmountOfPage { get; set; }
        public bool allPagesViews = false;
        public int PageCount { get; set; }
        public decimal AllPrise { get; set; }
    }
}
