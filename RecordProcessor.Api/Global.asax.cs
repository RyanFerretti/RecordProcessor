using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using RecordProcessor.Api.IoC;
using RecordProcessor.Application;
using RecordProcessor.Application.Domain;

namespace RecordProcessor.Api
{
    public class WebApiApplication : HttpApplication
    {
        private string[] _recordPaths =
        {
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_comma.txt",
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_pipe.txt",
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_space.txt",
        };

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = BuildContainer();
            SetupData(container);
        }

        protected void SetupData(IContainer container)
        {
            var builder = container.Resolve<IBuilder<Record>>();
            var results = builder.Build(_recordPaths, "0");
            
            var newBuilder = new ContainerBuilder();
            newBuilder.Register(c => results).As<IEnumerable<Record>>();
            newBuilder.Update(container);
        }

        protected IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApiModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}
