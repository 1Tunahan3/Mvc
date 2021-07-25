using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


        public string Name { get; set; }


    }
}
