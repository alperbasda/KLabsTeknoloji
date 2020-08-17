using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class User : Entity
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        public byte[] PasswordHash { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
