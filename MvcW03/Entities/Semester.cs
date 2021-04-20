using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcW03.Entities
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }

        public int SNumber { get; set; }

        public string Name { get; set; }
    }
}
