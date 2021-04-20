using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcW03.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "Name must be completed!!!!")]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PhotoPath { get; set; }

    }
}
