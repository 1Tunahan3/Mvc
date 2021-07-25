using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Department : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
