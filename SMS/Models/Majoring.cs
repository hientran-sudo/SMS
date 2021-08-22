using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Majoring
    {
        public Major Major { get; set; }
        public int MajorId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
