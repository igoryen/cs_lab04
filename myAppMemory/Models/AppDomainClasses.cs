using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myAppMemory.Models
{
    public class Person
    {
        public Person()
        {
            FirstName = LastName = Phone = string.Empty;
        }

        public Person(string f, string l, string p)
        {
            FirstName = f;
            LastName = l;
            Phone = p;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "nnn-nnn-nnnn")]
        public string Phone { get; set; }
    }

    public class Student : Person
    {
        public Student()
        {
            StudentNumber = string.Empty;
        }

        public Student(string f, string l, string p, string sid)
            : base(f, l, p)
        {
            StudentNumber = sid;
        }

        [Required]
        [RegularExpression("^[0][0-9]{8}$", ErrorMessage = "0 followed by 8 digits")]
        public string StudentNumber { get; set; }
    }
}