using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class ViewModel
    {
        public IEnumerable<Majoring> Majorings { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Major> Majors { get; set; }
    }
}
