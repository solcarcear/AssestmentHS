﻿using CaaoBakery.Domain.Entities;

namespace CaaoBakery.Application.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
