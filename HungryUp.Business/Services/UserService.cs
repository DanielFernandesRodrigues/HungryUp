using GameEndpoints.Common.Validations;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Model;

namespace HungryUp.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = _repository.Get(email);
            PasswordAssertionConcern.AssertIsSame(user.Password, password);
            return user;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
