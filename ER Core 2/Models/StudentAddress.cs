using System;
using System.Collections.Generic;

namespace ER_Core_2.Models
{
   public class StudentAddress
   {
      public int StudentId { get; set; }
      public string Address2 { get; set; }
      public string Address1 { get; set; }
      public string State { get; set; }
      public string City { get; set; }
      public Student Student { get; set; }
      //public virtual ICollection<Student> Student { get; set; } = new HashSet<Student>();
   }
}