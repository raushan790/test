using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentexpat.com.Models
{
    public partial class Schools
    {
        public Schools()
        {
            Programs = new HashSet<Programs>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<Programs> Programs { get; set; }
    }
}
