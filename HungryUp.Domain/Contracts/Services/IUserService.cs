using HungryUp.Domain.Model;
using System;

namespace HungryUp.Domain.Contracts.Services
{
    public interface IUserService : IDisposable
    {
        User Authenticate(string email, string password);
    }
}
