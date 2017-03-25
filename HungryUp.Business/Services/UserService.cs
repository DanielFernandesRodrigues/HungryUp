using GameEndpoints.Common.Validations;
using HungryUp.Common.Resources;
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
            User user = GetByEmail(email);
            AssertionConcern.AssertArgumentNotNull(user, ErrorMessages.UserNotFound);
            PasswordAssertionConcern.AssertIsValid(password);
            PasswordAssertionConcern.AssertPasswordIsSame(user.Password, password);
            return user;
        }

        public User Add(string name, string email, string password)
        {
            User user = GetByEmail(email);
            AssertionConcern.AssertArgumentFalse(user != null, ErrorMessages.UserAlreadyExists);

            user = new User(name, email, password);
            user.ValidateCadastration();

            return _repository.Add(user);
        }

        public User GetByEmail(string email)
        {
            AssertionConcern.AssertArgumentNotNull(email, ErrorMessages.InvalidEmail);
            email = email.ToLower().Trim();
            EmailAssertionConcern.AssertIsValid(email);
            return _repository.GetByEmail(email);
        }
        
        public void Remove(string email)
        {
            User user = GetByEmail(email);
            AssertionConcern.AssertArgumentNotNull(user, ErrorMessages.UserNotFound);
            _repository.Delete(user);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
