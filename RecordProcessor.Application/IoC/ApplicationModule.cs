using Autofac;
using RecordProcessor.Application.Validators;

namespace RecordProcessor.Application.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecordProcessorFromFile>().As<IRecordProcessor>();
            builder.RegisterType<ArgumentsValidator>().As<IValidator<string[]>>();
        }
    }
}
