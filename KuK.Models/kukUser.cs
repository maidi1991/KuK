using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KuK.Model
{
    public class kukUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public int UserID { get; set; }
        public ICollection<kukNotice> Notices { get; set; }
        public string PassworHash { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
