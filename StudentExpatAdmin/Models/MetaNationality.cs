using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Nationality.MetaNationality))]
    public partial class Nationality
    {
        private class MetaNationality
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Nationality")]
            public string Nationality1 { get; set; }
        }
    }
}
