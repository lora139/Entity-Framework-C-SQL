using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ER_Core_2.Models
{
   public class Student
   {
      public int StudentId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int? StandardId { get; set; }
      public DateTime? DateOfBirth { get; set; }
      public decimal Height { get; set; }
      public float Weight { get; set; }

      //public string Grade { get; set; }

      public Standard Standard { get; set; }
      public StudentAddress StudentAddress { get; set; }
      //public virtual ICollection<StudentAddress> StudentAddress { get; set; } = new HashSet<StudentAddress>();
      public virtual ICollection<StudentCourse> StudentCourse { get; set; } = new HashSet<StudentCourse>();
   }
}