using Autofac;
using RecordProcessor.Application.IoC;

namespace RecordProcessor.Console.IoC
{
    public class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule());
        }
    }
}