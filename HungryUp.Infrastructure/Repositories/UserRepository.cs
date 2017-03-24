using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System.Linq;

namespace HungryUp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            this._context = context;
        }

        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
