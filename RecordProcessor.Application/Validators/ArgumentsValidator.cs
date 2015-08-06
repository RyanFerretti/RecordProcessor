using System.Collections.Generic;
using System.Linq;

namespace RecordProcessor.Application.Validators
{
    public class ArgumentsValidator : IValidator<string[]>
    {
        private readonly IContentFinder _finder;

        public ArgumentsValidator(IContentFinder finder)
        {
            _finder = finder;
        }

        public ValidationResult IsValid(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return new ValidationResult{IsValid = false, ErrorMessage = "args are required"};
            }
            return ValidateFilesExist(args);
        }

        private ValidationResult ValidateFilesExist(string[] args)
        {
            var errors = new List<string>();
            foreach (var path in args)
            {
                if (!_finder.Exists(path))
                {
                    errors.Add(string.Format("{0} is not a valid file path",path));
                }
            }
            return new ValidationResult {IsValid = !errors.Any(), ErrorMessage = string.Join("\n", errors)};
        }
    }
}
