using System.ComponentModel;

namespace YasslayMVC.Models
{
    public class UsersModel
    {
        public int UserID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Type of User")]
        public string UserType { get; set; }
        public string State { get; set; }
    }
}
