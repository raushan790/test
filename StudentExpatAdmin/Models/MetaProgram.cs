using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Programs.Metadata))]
    public partial class Programs
    {
        private class Metadata
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Tuition { get; set; }
            [Display(Name = "Short Description")]
            public string ShortDesc { get; set; }
            [Display(Name = "Full Description")]
            public string FullDesc { get; set; }
            public int? Schoolid { get; set; }
            public int? LanguageId { get; set; }
            public int? ProgramTypeId { get; set; }
            [Display(Name = "Program Type")]
            public ProgramTypes ProgramType { get; set; }
        }
    }
}
