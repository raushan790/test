using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    public partial class ProgramTypes
    {
        public ProgramTypes()
        {
            Programs = new HashSet<Programs>();
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Program Type")]
        public string ProgramType { get; set; }

        public ICollection<Programs> Programs { get; set; }
    }
}
