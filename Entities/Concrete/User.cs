using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<OperationClaim> OperationClaims { get; set; }
    }
}
