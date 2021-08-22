using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EnrollInfo> EnrollInfos { get; set; }
        public DbSet<Majoring> Majorings { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Majoring>().HasKey(ma => new { ma.MajorId, ma.StudentId });

            // set foreign keys 
            modelBuilder.Entity<Majoring>().HasOne(ma => ma.Major)
                .WithMany(m => m.Majorings)
                .HasForeignKey(ma => ma.MajorId);
            modelBuilder.Entity<Majoring>().HasOne(ma => ma.Student)
                .WithMany(st => st.Majorings)
                .HasForeignKey(ma => ma.StudentId);
            modelBuilder.Entity<EnrollInfo>().HasKey(en => new { en.EnrollmentId, en.CourseId });

            // set foreign keys 
            modelBuilder.Entity<EnrollInfo>().HasOne(en => en.Enrollment)
                .WithMany(e => e.EnrollInfos)
                .HasForeignKey(en => en.EnrollmentId);
            modelBuilder.Entity<EnrollInfo>().HasOne(en => en.Course)
                .WithMany(co => co.EnrollInfos)
                .HasForeignKey(en => en.CourseId);

        }
    }
}
    
