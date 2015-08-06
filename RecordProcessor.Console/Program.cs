using Autofac;
using RecordProcessor.Application;
using RecordProcessor.Console.IoC;

namespace RecordProcessor.Console
{
    public class Program
    {
        public const int Success = 0;
        public const int Error = -1;

        public static int Main(string[] args)
        {
            var builder = BuildContainer();
            var result = InitializeAndRunApplication(args, builder);
            return result.Success ? Success : Error;
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConsoleModule());
            return builder.Build();
        }

        private static FileProcessedResult InitializeAndRunApplication(string[] args, IContainer builder)
        {
            FileProcessedResult result;
            using (var scope = builder.BeginLifetimeScope())
            {
                var processor = scope.Resolve<IRecordProcessor>();
                result = processor.Run(args);
            }
            return result;
        }

    }
}
