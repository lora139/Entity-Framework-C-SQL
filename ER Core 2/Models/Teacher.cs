using System.Collections.Generic;

namespace ER_Core_2.Models
{
   public class Teacher
   {
      public int TeacherId { get; set; }
      public int StandardId { get; set; }
      public string TeacherName { get; set; }
      //public object Standard { get; set; }
      public Standard Standard{ get; set; }
      public virtual ICollection<Course> Course { get; set; } = new HashSet<Course>();
   }
}