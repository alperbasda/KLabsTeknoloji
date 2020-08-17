using System.Collections.Generic;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Entities.Concrete;

namespace KLAbs.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}