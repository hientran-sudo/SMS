﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string Term { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
