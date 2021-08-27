using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Major
    {
        public int MajorId { get; set; }
        public string Title { get; set; }
        public ICollection<Majoring> Majorings { get; set; }
    }
}
