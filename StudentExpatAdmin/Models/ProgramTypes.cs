using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class ProgramTypes
    {
        public ProgramTypes()
        {
            Programs = new HashSet<Programs>();
        }

        public int Id { get; set; }
        public string ProgramType { get; set; }

        public ICollection<Programs> Programs { get; set; }
    }
}
