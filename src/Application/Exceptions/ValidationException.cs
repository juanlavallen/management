using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("One or more errors occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage).ToDictionary(failure => failure.Key, failure => failure.ToArray());
        }
    }
}