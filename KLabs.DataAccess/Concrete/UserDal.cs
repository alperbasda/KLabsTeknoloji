using System.Collections.Generic;
using System.Linq;
using KLabs.Core.DataAccess.Concrete;
using KLAbs.DataAccess.Abstract;
using KLabs.DataAccess.Core;
using KLabs.Entities.Concrete;

namespace KLabs.DataAccess.Concrete
{
    public class UserDal : EntityRepositoryBase<User,KLabsContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new KLabsContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}