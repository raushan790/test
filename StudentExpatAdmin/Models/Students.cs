using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Students
    {
        public Students()
        {
            Enrollments = new HashSet<Enrollments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Nationality { get; set; }
        public bool? CurrentStudent { get; set; }
        public decimal? TotalTuition { get; set; }
        public decimal? TotalCommision { get; set; }
        public DateTime? FollowUp { get; set; }
        public string LastEnrollment { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
