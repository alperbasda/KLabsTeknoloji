using Autofac;
using KLabs.Business.Abstract;
using KLabs.Business.Concrete;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Core.DataAccess.Concrete;
using KLabs.Core.Security.Jwt;
using KLabs.DataAccess.Abstract;
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

            builder.RegisterType<AboutUsManager>().As<IAboutUsService>();
            builder.RegisterType<AboutUsDal>().As<IAboutUsDal>();

            builder.RegisterType<PrivacyManager>().As<IPrivacyService>();
            builder.RegisterType<PrivacyDal>().As<IPrivacyDal>();

            builder.RegisterType<ReferenceManager>().As<IReferenceService>();
            builder.RegisterType<ReferenceDal>().As<IReferenceDal>();

            builder.RegisterType<ServiceManager>().As<IServiceService>();
            builder.RegisterType<ServiceDal>().As<IServiceDal>();

            builder.RegisterType<SolutionManager>().As<ISolutionService>();
            builder.RegisterType<SolutionDal>().As<ISolutionDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CacheManager>().As<ICacheService>().SingleInstance();

            builder.RegisterType<KLabsContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(QueryableRepositoryBase<>)).As(typeof(IQueryableRepositoryBase<>));

        }
    }
}