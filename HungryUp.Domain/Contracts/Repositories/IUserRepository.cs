using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetByEmail(string email);
        User Add(User user);
        void Delete(User user);
    }
}
