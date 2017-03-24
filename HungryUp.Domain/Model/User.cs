using GameEndpoints.Common.Validations;

namespace HungryUp.Domain.Model
{
    public class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        protected User() { }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public void Validate()
        {
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Password);
            this.Password = PasswordAssertionConcern.Encrypt(this.Password);
        }
    }
}
