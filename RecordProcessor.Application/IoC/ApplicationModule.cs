using Autofac;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Parsers;
using RecordProcessor.Application.Validators;

namespace RecordProcessor.Application.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecordProcessorFromFile>().As<IRecordProcessor>();
            builder.RegisterType<ArgumentsValidator>().As<IValidator<string[]>>();
            builder.RegisterType<RecordParser>().As<IParser>();
            builder.RegisterType<RecordsBuilder>().As<IBuilder<Record>>();
        }
    }
}
