using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class SchoolType
    {
        public int Id { get; set; }
        public string SchoolType1 { get; set; }
        public int? LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
