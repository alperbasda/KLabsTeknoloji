using System;
using System.Collections.Generic;
using System.Net;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Message;
using KLabs.Core.Security.Hashing;
using KLabs.Core.Security.Jwt;
using KLAbs.DataAccess.Abstract;
using KLabs.Entities.ComplexTypes.User;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }


        public DataResponse Register(PostUserRegisterModel model)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            Add(user);
            return new DataResponse
            {
                Data = user,
                Success = true,
                Message = string.Join("Kayıt Oldu", user.FirstName + " " + user.LastName),
                StatusCode = HttpStatusCode.Created
            };
        }

        private void Add(User user)
        {
            if (!_userDal.SetState(user, EntityState.Added))
                throw new Exception("Kayıtta Hata Oldu");
        }

        public DataResponse Login(PostUserLoginModel model)
        {
            var userToCheck = GetByMail(model.Email);
            if (userToCheck == null || !HashingHelper.VerifyPasswordHash(model.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new DataResponse
                {
                    Success = false,
                    Message = Messages.UserLoginFailed,
                    StatusCode = HttpStatusCode.Unauthorized,
                };
            }

            return new DataResponse
            {
                Success = true,
                Message = string.Format(Messages.UserLoginSuccess, $"{userToCheck.FirstName } {userToCheck.LastName}"),
                Data = userToCheck,
                StatusCode = HttpStatusCode.OK
            };
        }

    
        public DataResponse CreateAccessToken(User user)
        {
            var claims = GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new DataResponse
            {
                Message = Messages.UserAccessTokenCreated,
                Success = true,
                Data = accessToken,
                StatusCode = HttpStatusCode.Created
            };
        }

    
        private User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

   
    }
}