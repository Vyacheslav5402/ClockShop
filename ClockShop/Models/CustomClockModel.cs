using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClockShop.Models
{
    public class CustomClockModel
    {
        public int Id { get; set; }
        [Display(Name = "Watchband")]
        public string Watchband { get; set; }
        [Display(Name = "ClockFase")]
        public string ClockFase { get; set; }
        [Display(Name = "ClockHands")]
        public string ClockHands { get; set; }
        [Display(Name = "ClockCase")]
        public string ClockCase { get; set; }
    }
}
