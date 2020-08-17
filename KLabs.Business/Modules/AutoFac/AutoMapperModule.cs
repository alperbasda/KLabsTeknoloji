using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;


namespace KLabs.Business.Modules.AutoFac
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().AutoActivate().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }

    }
}
