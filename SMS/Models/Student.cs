using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Majoring> Majorings { get; set; }
    }
}
