using ErrorOr;

namespace CaaoBakery.Domain.Common.DomainErrors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Authentication.InvalidCredentials",
                description: "Invalid credentials.");

        }
    }
}
