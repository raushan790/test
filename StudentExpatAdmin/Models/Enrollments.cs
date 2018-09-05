using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Enrollments
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Tuition { get; set; }
        public decimal? Comission { get; set; }
        public int? ProgramId { get; set; }
        public string Comments { get; set; }
        public DateTime? Followup { get; set; }
        public string Agent { get; set; }
        public DateTime? DatePaid { get; set; }

        public Programs Program { get; set; }
        public Students Student { get; set; }
    }
}
