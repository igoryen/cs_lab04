using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myAppMemory.Models {
  public class DataContext : DbContext {
    public DataContext() : base("name=DataContext") { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Cancellation> Cancellations { get; set; }
    public DbSet<Message> Messages { get; set; }


    public DbSet<MyUserInfo> MyUserInfo { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.StudentFull> StudentFulls { get; set; }

    public System.Data.Entity.DbSet<myAppMemory.ViewModels.FacultyPublic> FacultyPublics { get; set; }
  }
}