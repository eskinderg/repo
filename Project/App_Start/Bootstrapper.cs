using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Project.Data;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Project.App_Start
{
    public static class Bootstrapper
    {

        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
           // AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            //builder.RegisterType<ExpenseRepository>().As<IExpenseRepo>().InstancePerRequest();

            // builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //         .AsClosedTypesOf(typeof(IRepository<>)).AsImplementedInterfaces();

            builder.Register(u => new UnitOfWork(new ApplicationDbContext())).As<IUnitOfWork>();

            #region Comments
            //builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            /*builder.RegisterAssemblyTypes(typeof(NewsRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(NewsService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();*/

            /*builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
                .Where(t => t.Name.EndsWith("Authentication"))
                .AsImplementedInterfaces().InstancePerRequest();
                */
            /*
                        builder.Register(
                            c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new JuventusNewsApkEntities())))
                            .As<UserManager<ApplicationUser>>().InstancePerRequest();
                            */
            #endregion

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}