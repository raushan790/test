using System;
using System.Collections.Generic;

namespace studentexpat.com.Models
{
    public partial class Schools
    {
        public Schools()
        {
            Agreements = new HashSet<Agreements>();
            Programs = new HashSet<Programs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<Agreements> Agreements { get; set; }
        public ICollection<Programs> Programs { get; set; }
    }
}
