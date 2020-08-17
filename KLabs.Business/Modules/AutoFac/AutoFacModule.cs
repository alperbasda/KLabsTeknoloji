using Autofac;
using KLabs.Business.Abstract;
using KLabs.Business.Concrete;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Core.DataAccess.Concrete;
using KLabs.Core.Security.Jwt;
using KLAbs.DataAccess.Abstract;
using KLabs.DataAccess.Concrete;
using KLabs.DataAccess.Core;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Modules.AutoFac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<KLabsContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(QueryableRepositoryBase<>)).As(typeof(IQueryableRepositoryBase<>));

        }
    }
}