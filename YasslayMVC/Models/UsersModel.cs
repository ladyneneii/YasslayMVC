using System.ComponentModel;

namespace YasslayMVC.Models
{
    public class UsersModel
    {
        public int UserID { get; set; }
        [DisplayName("User Name")]
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string UserType { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}
