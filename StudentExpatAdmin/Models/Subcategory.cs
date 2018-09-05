using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            ProgramCategories = new HashSet<ProgramCategories>();
        }

        public int Id { get; set; }
        public int? SubCategoryId { get; set; }
        public int? CategoryId { get; set; }
        public string Subcategory1 { get; set; }
        public int? Languageid { get; set; }

        public Category Category { get; set; }
        public Language Language { get; set; }
        public ICollection<ProgramCategories> ProgramCategories { get; set; }
    }
}
