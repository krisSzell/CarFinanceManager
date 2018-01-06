using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using CarFinanceManager.Access;
using CarFinanceManager.Core.UseCases.Logging;
using CarFinanceManager.Persistence;
using CarFinanceManager.Persistence.Repositories;
using CarFinanceManager.Persistence.Repositories.Interfaces;

namespace CarFinanceManager
{
    public class AutofacConfig
    {
        public static AutofacWebApiDependencyResolver Configure()
        {
            var builder = new ContainerBuilder();
            registerInstances(builder);

            var container = builder.Build();

            return new AutofacWebApiDependencyResolver(container);
        }

        private static void registerInstances(ContainerBuilder builder)
        {
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork());
            builder.RegisterInstance<IClaimsResolver>(new ClaimsResolver());
            builder.RegisterInstance<ILogsRepository>(new LogsRepository(new LoggingDbContext()));
            builder.RegisterInstance<ILoggingService>(new LoggingService(new LogsRepository(new LoggingDbContext())));
            builder.RegisterInstance<IAuthRepository>(new AuthRepository(new ApplicationDbContext()));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}