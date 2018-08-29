using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{

    [ModelMetadataType(typeof(ProgramTypes.MetaProgramTypes))]
    public partial class ProgramTypes
    {
        private class MetaProgramTypes
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Program Type")]
            public string ProgramType { get; set; }

        }
    }
}
