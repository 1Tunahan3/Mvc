using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Course:IEntity
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
