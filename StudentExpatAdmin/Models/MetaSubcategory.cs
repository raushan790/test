using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
   [ModelMetadataType(typeof(Subcategory.MetaSubcategory))]
    public partial class Subcategory
    {
        private class MetaSubcategory
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Sub-Category Name")]
            public int? SubCategoryId { get; set; }
            [Display(Name = "Category Name")]
            public int? CategoryId { get; set; }
            [Display(Name = "Sub-Category")]
            public string Subcategory1 { get; set; }
            [Display(Name = "Language")]
            public int? Languageid { get; set; }

            public Category Category { get; set; }
            public Language Language { get; set; }
        }
    }
}
