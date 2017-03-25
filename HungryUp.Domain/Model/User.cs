using GameEndpoints.Common.Validations;
using HungryUp.Common.Resources;

namespace HungryUp.Domain.Model
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        protected User() { }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public void ValidateAutentication()
        {
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Password);
            this.Password = PasswordAssertionConcern.Encrypt(this.Password);
        }

        public void ValidateCadastration()
        {
            ValidateAutentication();
            AssertionConcern.AssertArgumentNotEmpty(this.Name, ErrorMessages.InvalidUserName);
        }
    }
}
