using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcW03.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LecturerId")]
        public int LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public Lecturer Lecturer { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
