using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using RecordProcessor.Api.IoC;
using RecordProcessor.Application;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Repositories;

namespace RecordProcessor.Api
{
    public class WebApiApplication : HttpApplication
    {
        private readonly string[] _recordPaths =
        {
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_comma.txt",
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_pipe.txt",
            "C:\\Users\\Ryan Ferretti\\Documents\\visual studio 2013\\Projects\\RecordProcessor\\records_space.txt",
        };

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = BuildContainer();
            SetupRecordsAndInMemoryDataStore(container);
        }

        protected void SetupRecordsAndInMemoryDataStore(IContainer container)
        {
            var builder = container.Resolve<IBuilder<Record>>();
            var results = builder.Build(_recordPaths, "0");
            var newBuilder = new ContainerBuilder();
            newBuilder.Register(c => new InMemoryRecordRepository(results.ToList())).As<IRecordRepository>().SingleInstance();
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
