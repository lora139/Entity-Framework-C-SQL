using System.Collections.Generic;

namespace ER_Core_2.Models
{
   public class Standard
   {
      public int StandardId { get; set; }
      public string Description { get; set; }
      public string StandardName { get; set; }
      //public Student Student { get; private set; }
      public virtual ICollection<Student> Student { get; set; } = new HashSet<Student>();
      public virtual ICollection<Teacher> Teacher { get; set; } = new HashSet<Teacher>();
   }
}