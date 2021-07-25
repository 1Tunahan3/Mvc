using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Semester : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int SNumber { get; set; }

        public string Name { get; set; }
    }
}
