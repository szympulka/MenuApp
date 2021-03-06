﻿using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using MenuApp.Services.UserService;
using MenuApp.Services.RecipeService;
using MenuApp.Services.QuestionService;
using System.Web.Mvc;
using MenuApp.Core;
using MenuApp.Core.Entities;
using MenuApp.Services.AuthorizationService;
using MenuApp.Services.AzureService;
using MenuApp.Services.BigDataService;
using MenuApp.Services.LogService;
using MenuApp.Services.HomeService;
using MenuApp.Services.MailService;
using MenuApp.Services.Fakes;

namespace MenuApp.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {

#if DEBUG
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //if(ConfigurationManager.AppSettings[""])

            #region Fakes
            builder.RegisterType<MailServiceFake>().As<IMailService>();
            builder.RegisterType<AzureServiceFake>().As<IAzureService>();
            #endregion
            builder.RegisterType<LogService>().As<ILogService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RecipeService>().As<IRecipeService>();
            builder.RegisterType<BigDataService>().As<IBigDataService>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<HomeSerivce>().As<IHomeSerivce>();
#else 
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //if(ConfigurationManager.AppSettings[""])
            builder.RegisterType<MailService>().As<IMailService>();
            builder.RegisterType<AzureService>().As<IAzureService>();
            builder.RegisterType<LogService>().As<ILogService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RecipeService>().As<IRecipeService>();
            builder.RegisterType<BigDataService>().As<IBigDataService>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
           builder.RegisterType<HomeSerivce>().As<IHomeSerivce>();
#endif

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}