using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class EnrollInfo
    {
        public Enrollment Enrollment { get; set; }
        public int EnrollmentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
    }
}
