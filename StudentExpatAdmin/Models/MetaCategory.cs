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
            [Display(Name = "Category Id")]
            public int? CategoryId { get; set; }
            [Display(Name = "Category")]
            public string Category1 { get; set; }
            public int? Languageid { get; set; }
        }
    }
}
