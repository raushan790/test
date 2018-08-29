using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    public partial class Language
    {
        public Language()
        {
            Category = new HashSet<Category>();
            Programs = new HashSet<Programs>();
            SchoolType = new HashSet<SchoolType>();
            Subcategory = new HashSet<Subcategory>();
        }
        [Key]      
        public int Id { get; set; }
        public string Language1 { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<Programs> Programs { get; set; }
        public ICollection<SchoolType> SchoolType { get; set; }
        public ICollection<Subcategory> Subcategory { get; set; }
    }
}
