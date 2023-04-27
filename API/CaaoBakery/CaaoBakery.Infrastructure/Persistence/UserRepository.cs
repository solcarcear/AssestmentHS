using CaaoBakery.Application.Common.Interfaces.Persistence;
using CaaoBakery.Domain.UserAggregate;

namespace CaaoBakery.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly CaaoBakeryDbContext _dbContext;

        public UserRepository(CaaoBakeryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Add(user);

            _dbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users
                .SingleOrDefault(u => u.Email == email);
        }
    }
}
