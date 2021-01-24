using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KuK.Model
{
    public class kukNotice
    {
        [Key]
        public int NoticeID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
