using Autofac;

namespace RecordProcessor.Application.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecordProcessorFromFile>().As<IRecordProcessor>();
        }
    }
}
