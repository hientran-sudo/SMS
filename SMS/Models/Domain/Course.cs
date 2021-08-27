using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public decimal Fee { get; set; }
        public int InstructorId { get; set; }
        public int MajorId { get; set; }
        public Instructor Instructor { get; set; }      
        public Major Major { get; set; }     
        public ICollection<EnrollInfo> EnrollInfos { get; set; }

    }
}
