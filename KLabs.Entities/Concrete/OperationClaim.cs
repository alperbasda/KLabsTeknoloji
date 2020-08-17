using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<UserOperationClaim> OperationClaimUsers { get; set; }
    }
}
