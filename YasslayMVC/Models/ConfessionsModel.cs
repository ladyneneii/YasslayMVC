using System.ComponentModel;

namespace YasslayMVC.Models
{
    public class ConfessionsModel
    {
        public int ConfessID { get; set; }
        public int UserID { get; set; }
        public string Relationship { get; set; }
        public string Message { get; set; }
        [DisplayName("Recipient's Last Name")]
        public string RecipientLN { get; set; }
        [DisplayName("Recipient's First Name")]
        public string RecipientFN { get; set; }
        public int GiftID { get; set; }
    }
}
