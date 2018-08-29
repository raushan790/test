using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    public partial class ProgramCategories
    {
        [Key]
        public int Id { get; set; }
        public int? ProgramId { get; set; }
        public int? SubcatId { get; set; }
        public int? CatId { get; set; }

        public Category Cat { get; set; }
        public Programs Program { get; set; }
        public Subcategory Subcat { get; set; }
    }
}
