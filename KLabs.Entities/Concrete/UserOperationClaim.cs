using System;
using System.ComponentModel.DataAnnotations.Schema;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class UserOperationClaim : Entity
    {
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid OperationClaimId { get; set; }

        [ForeignKey("OperationClaimId")]
        public virtual OperationClaim OperationClaim { get; set; }

    }
}
