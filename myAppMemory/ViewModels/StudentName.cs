using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myAppMemory.ViewModels {
  public class StudentName { // 1
    public int StudentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
  }
}

// StudentName (001 John Smith)
/* 1. a 3-column table row: StudentId, FirstName, LastName 
*
*/