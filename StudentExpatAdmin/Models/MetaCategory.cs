using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Category.Metadata))]
    public partial class Category
    {
        private class Metadata
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Category")]
            public int? CategoryId { get; set; }
            [Display(Name = "Category Name")]
            public string Category1 { get; set; }
            [Display(Name = "Language")]
            public int? Languageid { get; set; }
        }
    }
}
