using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Agreements.MetaAgreements))]
    public partial class Agreements
    {
        private class MetaAgreements
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "School Name")]
            public int? SchoolId { get; set; }
            public string Agreement { get; set; }
            [Display(Name = "Signed On")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? SignedOn { get; set; }
            public string Attachment { get; set; }
            public string Warnings { get; set; }
            public string Comments { get; set; }
            [Display(Name = "Follow-Up Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM//yyyy}")]
            public DateTime? FollowUp { get; set; }
            public Schools School { get; set; }
        }
    }
}
