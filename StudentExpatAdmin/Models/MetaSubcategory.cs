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
            [Display(Name = "Category Id")]
            public int? CategoryId { get; set; }
            [Display(Name = "Category")]
            public string Category1 { get; set; }
            public int? Languageid { get; set; }
        }
    }
}
