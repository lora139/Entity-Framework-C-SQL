using System.Collections.Generic;

namespace ER_Core_2.Models
{
   public class Course
   {
      public int CourseId { get; set; }
      public string CourseName { get; set; }
      public Teacher Teacher { get; set; }
      public int TeacherId { get; set; }

      public virtual ICollection<StudentCourse> StudentCourse { get; set; } = new HashSet<StudentCourse>();
   }
}