using Autofac;
using Core.Repositories;
using Service.Concrete;
using System.Reflection;
using Module = Autofac.Module;

namespace core_mvc_case.Modules
{
    public class ServicesModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repoAssembly = Assembly.GetAssembly(typeof(GenericRepository<>));
            var servicesAssembly = Assembly.GetAssembly(typeof(GenericService<>));

            builder.RegisterAssemblyTypes(repoAssembly)
                      .Where(x => x.Name.EndsWith("Repository"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(servicesAssembly)
                       .Where(x => x.Name.EndsWith("Service"))
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
        }

    }
}
