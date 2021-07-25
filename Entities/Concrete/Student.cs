using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Student : IEntity
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
