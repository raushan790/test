using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Schools.MetaSchools))]
    public partial class Schools
    {
        private class MetaSchools
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Logo { get; set; }
        }
    }

}
