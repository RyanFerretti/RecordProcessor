namespace RecordProcessor.Application
{
    public class FileProcessedResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { private get; set; }
        public string SuccessMessage { private get; set; }
        public string DisplayMessage { get { return Success ? SuccessMessage : ErrorMessage; } }
    }
}