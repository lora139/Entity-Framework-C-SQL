namespace ER_Core_2.Models
{
   public class StudentCourse
   {
      public int StudentId { get; set; }
      public int CourseId { get; set; }
      public Course Course { get; set; }
      public Student Student { get; set; }

   }
}