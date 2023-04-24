using CaaoBakery.Application.Common.Services;

namespace CaaoBakery.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
