using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Agreements
    {
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string Agreement { get; set; }
        public DateTime? SignedOn { get; set; }
        public string Attachment { get; set; }
        public string Warnings { get; set; }
        public string Comments { get; set; }
        public DateTime? FollowUp { get; set; }

        public Schools School { get; set; }
    }
}
