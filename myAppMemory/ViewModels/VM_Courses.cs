using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myAppMemory.ViewModels {
  public class CourseForList {

    [Key]
    public int CourseId { get; set; }
    public string CourseCode { get; set; }
  }
}