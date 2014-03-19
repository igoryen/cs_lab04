// 10. to bring in IdentityDbContext<>
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework; // 10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myAppMemory.Models {
  public class DataContext : IdentityDbContext<ApplicationUser> {
    public DataContext() : base("DefaultConnection") { }

    protected override void OnModelCreating(DbModelBuilder modelBuilder){
      base.OnModelCreating(modelBuilder);
      // Change the name of the table to be Users instead of AspNetUsers
      modelBuilder.Entity<IdentityUser>().ToTable("Users");
      modelBuilder.Entity<ApplicationUser>().ToTable("Users");
    }

    public DbSet<Cancellation> Cancellations { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    //public DbSet<Message> Messages { get; set; }
    public DbSet<MyUserInfo> MyUserInfo { get; set; }
    public DbSet<Student> Students { get; set; }



    public System.Data.Entity.DbSet<myAppMemory.ViewModels.StudentFull> StudentFulls { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.FacultyPublic> FacultyPublics { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.CourseFull> CourseFulls { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.CourseBase> CourseBases { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.StudentName> StudentNames { get; set; }

  }
}