using System.Collections.Generic;
using KLabs.Entities.ComplexTypes.User;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;

namespace KLabs.Business.Abstract
{
    public interface IUserService
    {
        DataResponse Register(PostUserRegisterModel model);

        DataResponse Login(PostUserLoginModel model);

        DataResponse CreateAccessToken(User user);

        List<OperationClaim> GetClaims(User user);

    }
}