using RecordProcessor.Application.Validators;

namespace RecordProcessor.Application
{
    public class RecordProcessorFromFile : IRecordProcessor
    {
        private readonly IValidator<string[]> _validator;
        private readonly IPrinter _printer;

        public RecordProcessorFromFile(IValidator<string[]> validator, IPrinter printer)
        {
            _validator = validator;
            _printer = printer;
        }

        public FileProcessedResult Run(string[] args)
        {
            var validationResult = _validator.IsValid(args);
            if (!validationResult.IsValid)
            {
                var failedResult = new FileProcessedResult{Success = false, ErrorMessage = validationResult.ErrorMessage};
                _printer.Print(failedResult.DisplayMessage);
                return failedResult;
            }
            // do something
            var result = new FileProcessedResult { Success = false, ErrorMessage = "not implemented" };
            _printer.Print(result.DisplayMessage);
            return result;
        }
    }
}