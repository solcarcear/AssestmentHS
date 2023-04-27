using CaaoBakery.Domain.UserAggregate;

namespace CaaoBakery.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
