using System.ComponentModel;

namespace YasslayMVC.Models
{
    public class GiftsModel
    {
        public int GiftID { get; set; }
        [DisplayName("Gift Name")]
        public string GiftName { get; set; }
        public int Price { get; set; }
        [DisplayName("Quantity Left")]
        public int QuantityLeft { get; set; }
        public string Status { get; set; }
    }
}
