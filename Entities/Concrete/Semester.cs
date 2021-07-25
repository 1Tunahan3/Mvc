using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }

        public int SNumber { get; set; }

        public string Name { get; set; }
    }
}
