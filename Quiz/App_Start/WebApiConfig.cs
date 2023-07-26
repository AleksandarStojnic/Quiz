using SimpleInjector.Lifestyles;
using SimpleInjector;
using System.Web.Http;
using Quiz.Interfaces;
using Quiz.Services;
using SimpleInjector.Integration.WebApi;
using Quiz.Models.Entities;
using Quiz.Context;
using System.Data.Entity;

namespace Quiz
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<DatabaseContext>(Lifestyle.Scoped);
            container.Register<IRepository<Question>, Quiz.Services.Repository<Question>>(Lifestyle.Scoped);
            container.Register<IRepository<Quizz>, Quiz.Services.Repository<Quizz>>(Lifestyle.Scoped);
            container.Register<IQuizService, QuizService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
