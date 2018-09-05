using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Programs
    {
        public Programs()
        {
            Enrollments = new HashSet<Enrollments>();
            ProgramCategories = new HashSet<ProgramCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Tuition { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public int? Schoolid { get; set; }
        public int? LanguageId { get; set; }
        public int? ProgramTypeId { get; set; }

        public Language Language { get; set; }
        public ProgramTypes ProgramType { get; set; }
        public Schools School { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
        public ICollection<ProgramCategories> ProgramCategories { get; set; }
    }
}
