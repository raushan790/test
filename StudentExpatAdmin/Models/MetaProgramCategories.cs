using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(ProgramCategories.MetaProgramCategories))]
    public partial class ProgramCategories
    {
        private class MetaProgramCategories
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Program Name")]
            public int? ProgramId { get; set; }
            [Display(Name = "Sub-Category Name")]
            public int? SubcatId { get; set; }
            [Display(Name = "Category Name")]
            public int? CatId { get; set; }

            public Category Cat { get; set; }
            public Programs Program { get; set; }
            public Subcategory Subcat { get; set; }

        }
    }
}
