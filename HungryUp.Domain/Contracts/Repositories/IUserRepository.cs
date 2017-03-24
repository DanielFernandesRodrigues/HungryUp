using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User Get(string email);
    }
}
