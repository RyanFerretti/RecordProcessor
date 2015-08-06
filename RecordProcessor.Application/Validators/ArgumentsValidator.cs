using System.Collections.Generic;
using System.Linq;

namespace RecordProcessor.Application.Validators
{
    public class ArgumentsValidator : IValidator<string[]>
    {
        private readonly IContentHelper _helper;

        public ArgumentsValidator(IContentHelper helper)
        {
            _helper = helper;
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
                if (!_helper.Exists(path))
                {
                    errors.Add(string.Format("{0} is not a valid file path",path));
                }
            }
            return new ValidationResult {IsValid = !errors.Any(), ErrorMessage = string.Join("\n", errors)};
        }
    }
}
