using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClockShop.Models
{
    public class EditClockItemModel
    {
        public int Id { get; set; }
        public string Watchband { get; set; }
        public string ClockFase { get; set; }
        public string ClockHands { get; set; }
        public string ClockCase { get; set; }
    }
}
