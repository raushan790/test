using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Students.MetaStudents))]
    public partial class Students
    {
        private class MetaStudents
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "First Name")]
            public string Name { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int? Nationality { get; set; }
            [Display(Name = "Current Student")]
            public bool? CurrentStudent { get; set; }
            [Display(Name = "Total Tuition")]
            public decimal? TotalTuition { get; set; }
            [Display(Name = "Total Commision")]
            public decimal? TotalCommision { get; set; }
            [Display(Name = "Follow-Up Date")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? FollowUp { get; set; }
            [Display(Name = "Last Enrollment")]
            public string LastEnrollment { get; set; }
            public string Nationality1 { get; set; }

        }
    }

}
