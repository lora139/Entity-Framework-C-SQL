using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Data;

#nullable disable

namespace ER_Core_2.Models
{
   public partial class SchoolDBContext : DbContext //SchoolContext class is derived from the DbContext class
   {
      public virtual DbSet<Course> Course { get; set; }
      public virtual DbSet<Standard> Standard { get; set; }
      public virtual DbSet<Student> Student { get; set; }
      public virtual DbSet<StudentAddress> StudentAddress { get; set; }
      public virtual DbSet<StudentCourse> StudentCourse { get; set; }
      public virtual DbSet<Teacher> Teacher { get; set; }

      public SchoolDBContext()
        {
        }
      //  public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
      //      : base(options)
      //  {
      //  }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //The OnConfiguring() method allows us to select and configure the data source to be used with a context using DbContextOptionsBuilder
      {
         if (!optionsBuilder.IsConfigured)
         {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
         }
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)  //The OnModelCreating() method allows us to configure the model using ModelBuilder Fluent API.
      {
         //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
         //OnModelCreatingPartial(modelBuilder);
         modelBuilder.Entity<Course>(entity =>
         {
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Teacher)
                .WithMany(p => p.Course)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Course_Teacher");
         });

         modelBuilder.Entity<Standard>(entity =>
         {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StandardName)
                .HasMaxLength(50)
                .IsUnicode(false);
         });

         modelBuilder.Entity<Student>(entity =>
         {
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.Property(e => e.Grade)
            //    .HasMaxLength(50)
            //    .IsUnicode(false);

            entity.HasOne(d => d.Standard)
                .WithMany(p => p.Student)
                .HasForeignKey(d => d.StandardId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Student_Standard");
         });

         modelBuilder.Entity<StudentAddress>(entity =>
         {
            entity.HasKey(e => e.StudentId);

            entity.Property(e => e.StudentId)
                .HasColumnName("StudentID")
                .ValueGeneratedNever();

            entity.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student)
                .WithOne(p => p.StudentAddress)
                .HasForeignKey<StudentAddress>(d => d.StudentId)
                .HasConstraintName("FK_StudentAddress_Student");
         });

         modelBuilder.Entity<StudentCourse>(entity =>
         {
            entity.HasKey(e => new { e.StudentId, e.CourseId });

            entity.HasOne(d => d.Course)
                .WithMany(p => p.StudentCourse)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentCourse_Course");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.StudentCourse)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentCourse_Student");
         });

         modelBuilder.Entity<Teacher>(entity =>
         {
            entity.Property(e => e.StandardId).HasDefaultValueSql("((0))");

            entity.Property(e => e.TeacherName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Standard)
                .WithMany(p => p.Teacher)
                .HasForeignKey(d => d.StandardId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Teacher_Standard");
         });


      }
      //entities
      public DbSet<Student> Students { get; set; } //DbSet<TEntity> properties of Student
      public DbSet<Course> Courses { get; set; } //DbSet<TEntity> properties of Course
      //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   }
}
