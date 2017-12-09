﻿using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using CarWash.Core.UseCases.Logging;
using CarWash.Persistence;
using CarWash.Persistence.Repositories;

namespace CarWash.App_Start
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
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork(new ApplicationDbContext()));
            builder.RegisterInstance<ILogsRepository>(new LogsRepository(new LoggingDbContext()));
            builder.RegisterInstance<ILoggingService>(new LoggingService(new LogsRepository(new LoggingDbContext())));
            builder.RegisterInstance<IAuthRepository>(new AuthRepository(new ApplicationDbContext()));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}