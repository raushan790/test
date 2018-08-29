using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Language.Metadata))]
    public partial class Language
    {        
        private class Metadata
        {
            [Key]
            public int Id { get; set; }
            [Display(Name ="Language")]
            public string Language1 { get; set; }
        }
    }
}
