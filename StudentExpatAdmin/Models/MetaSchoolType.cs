using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(SchoolType.MetaSchoolType))]
    public partial class SchoolType
    {
        private class MetaSchoolType
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "School Type")]
            public string SchoolType1 { get; set; }
            [Display(Name = "Language")]
            public int? LanguageId { get; set; }

            public Language Language { get; set; }
        }
    }
}
