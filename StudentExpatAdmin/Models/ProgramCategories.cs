using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class ProgramCategories
    {
        public int Id { get; set; }
        public int? ProgramId { get; set; }
        public int? SubcatId { get; set; }
        public int? CatId { get; set; }

        public Category Cat { get; set; }
        public Programs Program { get; set; }
        public Subcategory Subcat { get; set; }
    }
}
