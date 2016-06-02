﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Project.Services;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Project.Data;

namespace Project.App_Start
{
    public static class Bootstrapper
    {

        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfig.RegisterMappings();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

#region diffrent  Web.config
            //builder.Register<IDbContext>(c => new ApplicationDbContext()).InstancePerHttpRequest();
#endregion

            builder.RegisterType<ApplicationDbContext>().As<IDbContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<FolderService>().As<IFolderService>().InstancePerLifetimeScope();
            builder.RegisterType<ContentService>().As<IContentService>().InstancePerLifetimeScope();
            builder.RegisterType<ExpenseService>().As<IExpenseService>().InstancePerLifetimeScope();

#region Comments
//builder.RegisterType<ExpenseRepository>().As<IExpenseRepo>().InstancePerRequest();

// builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
//         .AsClosedTypesOf(typeof(IRepository<>)).AsImplementedInterfaces();

//builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();     // Single instance DBContext
//builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
//builder.RegisterType<ExpenseManager>().As<IExpenseManager>();
#endregion

#region Separate Injections
            /*

               builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>();
               builder.RegisterType<ContentRepository>().As<IContentRepository>();
               builder.RegisterType<FolderRepository>().As<IFolderRepository>();

            */
            #endregion

            builder.RegisterControllers(Assembly.GetExecutingAssembly());                   //Register all Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());                //Register all API's
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
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}