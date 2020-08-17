using System.Collections.Generic;
using KLabs.Entities.Concrete;

namespace KLabs.Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
