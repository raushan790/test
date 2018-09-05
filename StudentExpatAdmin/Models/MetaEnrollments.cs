using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    [ModelMetadataType(typeof(Enrollments.MetaEnrollments))]
    public partial class Enrollments
    {
        private class MetaEnrollments
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Student Name")]
            public int? StudentId { get; set; }
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? Date { get; set; }
            public decimal? Tuition { get; set; }
            public decimal? Comission { get; set; }
            [Display(Name = "Program Name")]
            public int? ProgramId { get; set; }
            public string Comments { get; set; }
            [Display(Name = "Follow-Up Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? Followup { get; set; }
            public string Agent { get; set; }
            [Display(Name = "Paid Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime? DatePaid { get; set; }

            public Programs Program { get; set; }
            public Students Student { get; set; }

            [Display(Name = "Full Name")]
            public string fullname
            {
                get { return Student.Name + ", " + Student.Lastname; }
            }
        }
    }

}
