using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IUserService : IDisposable
    {
        User GetByEmail(string email);
        User Authenticate(string email, string password);
        User Add(string name, string email, string password);
        void Remove(string email);
    }
}
