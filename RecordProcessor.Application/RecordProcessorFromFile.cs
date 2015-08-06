namespace RecordProcessor.Application
{
    public class RecordProcessorFromFile : IRecordProcessor
    {
        private readonly IPrinter _printer;

        public RecordProcessorFromFile(IPrinter printer)
        {
            _printer = printer;
        }

        public FileProcessedResult Run(string[] args)
        {
            var result = new FileProcessedResult{ErrorMessage = "not implemented"};
            // do something
            _printer.Print(result.DisplayMessage);
            return result;
        }
    }
}