using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace studentexpat.com.Models
{
    public partial class Programs
    {
        public Programs()
        {
            ProgramCategories = new HashSet<ProgramCategories>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Tuition { get; set; }
        //[Display(Name = "Short Description")]
        public string ShortDesc { get; set; }
        //[Display(Name = "Full Description")]
        public string FullDesc { get; set; }
        public int? Schoolid { get; set; }
        public int? LanguageId { get; set; }
        //[Display(Name = "Program Type")]
        public int? ProgramTypeId { get; set; }

        public Language Language { get; set; }
        public ProgramTypes ProgramType { get; set; }
        public Schools School { get; set; }
        public ICollection<ProgramCategories> ProgramCategories { get; set; }
    }
}
