using ER_Core_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ER_Core_2
{
   class Program
   {
      static void Main(string[] args)
      {
         //Disconnected entity
         //var std = new Student() { FirstName = "Bill" };

         //INSERT RELATIONAL DATA
         //var stdAddress = new StudentAddress()
         //{
         //   Address1 = "South",
         //   Address2 = "East",
         //   City = "SFO",
         //   State = "CA",
         //};

         //var std = new Student()
         //{
         //   FirstName = "Steve",
         //   StudentAddress = stdAddress
         //};

         //INSERT MULTIPLE RECORDS
         //var studentList = new List<Student>() {
         //   new Student(){ FirstName = "Carl" },
         //   new Student(){ FirstName = "Samon" }
         //};

         //UPDATE DISCONNECT SENERIO
         //var stud = new Student() { StudentId = 3, FirstName = "Bill" };
         //stud.FirstName = "Lora";

         //ENTITY TO BE DELETED
         var student = new Student()
         {
            StudentId = 8
         };

         using (var context = new SchoolDBContext())
         {
            //ADD
            //var std = new Student()
            //{
            //   FirstName = "Bill"
            //};
            //context.Students.Add(std);

            //ADD ON FIRST POSITION
            //var std = context.Students.First<Student>();
            //update 
            //std.FirstName = "Grinch";
            //std.LastName = "Filch";

            //DELETE
            //context.Students.Remove(std);

            //1. Attach an entity to context with Added EntityState
            //context.Add<Student>(std);

            //UPDATE
            //context.Update<Student>(stud);

            //DELETE FROM DISCONNECTED SENERIO
            context.Remove<Student>(student);

            context.SaveChanges();
         }
      }
      //querying

      //private static void Main(string[] args)
      //{
      //   var context = new SchoolDBContext();
      //   var studentsWithSameName = context.Students
      //                                     .Where(s => s.FirstName == GetName())
      //                                     .ToList();
      //   PrintResult(studentsWithSameName);
      //}

      //public static string GetName()
      //{
      //   return "Bill";
      //}
      public static void PrintResult(List<Student> students)
      {
         foreach (var student in students)
         {
            Console.WriteLine(student.FirstName);
         }
            Console.ReadLine();
      }

   }
}
