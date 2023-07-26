using Quiz.Context;
using System.Data.Entity;
using System.Web;
using System.Web.Http;

namespace Quiz
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DatabaseInitializer());

            DatabaseContext databaseContext = new DatabaseContext();
            databaseContext.Database.Initialize(true);
        }
    }
}
