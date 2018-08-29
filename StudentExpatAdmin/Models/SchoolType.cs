using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    public partial class SchoolType
    {
        [Key]
        public int Id { get; set; }
        public string SchoolType1 { get; set; }
        public int? LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
