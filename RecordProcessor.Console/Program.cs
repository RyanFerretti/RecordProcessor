using Autofac;
using RecordProcessor.Application;
using RecordProcessor.Console.IoC;

namespace RecordProcessor.Console
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = BuildContainer();
            using (var scope = builder.BeginLifetimeScope())
            {
                var processor = scope.Resolve<IRecordProcessor>();
                processor.Run(args);
            }
            return 0;
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConsoleModule());
            return builder.Build();
        }
    }
}
