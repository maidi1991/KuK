using System.ComponentModel.DataAnnotations;

namespace KuK.Model
{
    public class kukMessage
    {
        public int MessageType { get; set; } //0 for info, 1 for error, 2 for warning
        public string Message { get; set; }
        [Key]
        public int MessageID { get; set; }
        public int UserID { get; set; }
    }
}
