using System.Reflection;
using Autofac;
using Autofac.Core;
using Core.Repositories;
using Core.Services;
using Repository.Repositories;
using Repository.UnitOfWorks;

using Core.UnitOfWork;
using Repository;
using Service.Mapping;
using Service.Services;
using Module = Autofac.Module;

namespace EmployeeSelect.Modules{

public class RepoServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>))
            .InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();




        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterType<EmployeeServiceWithNoCaching>().As<IEmployeeService>();

    }
}
    
}