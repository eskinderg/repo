using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Project.Data;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Project.Data.ExpenseManager;
using Project.Data.IRepositories;
using Project.Data.Repositories;
using Project.Data.UnitOfWork;

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

#region Comments
            //builder.RegisterType<ExpenseRepository>().As<IExpenseRepo>().InstancePerRequest();

            // builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //         .AsClosedTypesOf(typeof(IRepository<>)).AsImplementedInterfaces();
#endregion
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ExpenseManager>().As<IExpenseManager>();
            builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());       //Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());    //API

#region Comments

            //builder.Register(u => new UnitOfWork(new ApplicationDbContext())).As<IUnitOfWork>();

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
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}