using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Category
    {
        public Category()
        {
            ProgramCategories = new HashSet<ProgramCategories>();
            Subcategory = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Category1 { get; set; }
        public int? Languageid { get; set; }

        public Language Language { get; set; }
        public ICollection<ProgramCategories> ProgramCategories { get; set; }
        public ICollection<Subcategory> Subcategory { get; set; }
    }
}
