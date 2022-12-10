using System.ComponentModel;

namespace YasslayMVC.Models
{
    public class UsersModel
    {
        public int UserID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = default!;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        [DisplayName("Type of User")]
        public string UserType { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}
